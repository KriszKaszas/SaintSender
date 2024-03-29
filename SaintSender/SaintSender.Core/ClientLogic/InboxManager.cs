﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Threading;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;


namespace SaintSender.Core
{
    public class InboxManager
    {
        public ObservableCollection<ReceivedEmail> ReceivedEmails { get; set; } = new ObservableCollection<ReceivedEmail>();
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        public void StartGettinMessages(EmailAccount currentAccount)
        {
            _timer.Interval = TimeSpan.FromMilliseconds(5000);
            _timer.Tick += (sender, args) => DownloadMessagesAsync(currentAccount);
            _timer.Start();
        }

        public void StopGettingMessages()
        {
            _timer.Stop();
        }

        private void ManageEmailChanges(List<ReceivedEmail> downloaded)
        {
            var toAdd = downloaded.Where(email => !ReceivedEmails.Contains(email)).ToList();
            var toRemove = ReceivedEmails.Where(email => !downloaded.Contains(email)).ToList();
            toAdd.ForEach(email => ReceivedEmails.Add(email));
            toRemove.ForEach(email => ReceivedEmails.Remove(email));
        }


        private async void DownloadMessagesAsync(EmailAccount currentAccount)
        {
            var messages = await Task<List<ReceivedEmail>>.Factory.StartNew(DownloadMessages, currentAccount);
            ManageEmailChanges(messages);
        }


        private IList<UniqueId> Connection(ImapClient client, EmailAccount currentAccount, FolderAccess accessMode = FolderAccess.ReadWrite)
        {
            client.Connect(currentAccount.IMAPServer, currentAccount.Port, SecureSocketOptions.SslOnConnect);
            client.Authenticate(currentAccount.EmailAddress, currentAccount.ApplicationPassword);
            //client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
            //client.Authenticate("saintsender2.0@gmail.com", "atssddvndnffxggx");
            client.Inbox.Open(accessMode);
            return client.Inbox.Search(SearchQuery.All);
        }


        public List<ReceivedEmail> DownloadMessages(Object currentEmail)
        {
            EmailAccount currentAccount = (EmailAccount)currentEmail;
            var messages = new List<ReceivedEmail>();
            using (var client = new ImapClient())
            {
                var uids = Connection(client, currentAccount);
                foreach (var uid in uids)
                {
                    try
                    {
                        var receivedEmail = new ReceivedEmail(uid, client.Inbox.GetMessage(uid));
                        messages.Add(receivedEmail);
                    }
                    catch (MessageNotFoundException)
                    {
                        Console.WriteLine("No messages found, inbox is empty.");
                    }
                }
                client.Disconnect(true);
                return messages;
            }
        }

        public async void DeleteMessagesAsync(DeleteMessageData messageData)
        {
            await Task.Factory.StartNew(DeleteMessages, (object)messageData);
        }

        private void DeleteMessages(object state)
        {
            var deleteMessageData = (DeleteMessageData)state;
            var currentAccount = deleteMessageData.currentAccount;
            var messages = deleteMessageData.uids;
            using (var client = new ImapClient())
            {
                Connection(client, currentAccount);
                client.Inbox.AddFlags(messages, MessageFlags.Deleted, false);
                client.Inbox.Expunge();
                client.Disconnect(true);
            }
        }

        public bool ValidateEmailFormat(string emailAddress)
        {
            try
            {
                MailAddress address = new MailAddress(emailAddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
   
