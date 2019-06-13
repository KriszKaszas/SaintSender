using SaintSender.Core;
using System;
using System.Collections.Generic;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using MimeKit;


namespace SaintSender.ViewModels
{
    public class MainViewModel
    {
        public InboxManager InboxManager { get; set; } = new InboxManager();
        public EmailComposer EmailComposer { get; set; } = new EmailComposer();

        public bool IsEmailValid(string emailAddress)
        {
            return InboxManager.ValidateEmailFormat(emailAddress);
        }

        public void GetUserEmails()
        {
            try
            {
                InboxManager.StartGettinMessages();
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
