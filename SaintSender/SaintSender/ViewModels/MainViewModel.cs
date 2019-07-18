using SaintSender.Core;
using System;
using MailKit.Security;
using System.Collections.ObjectModel;

namespace SaintSender.ViewModels
{
    public class MainViewModel
    {
        public InboxManager inboxManager = new InboxManager();
        public EmailComposer emailComposer = new EmailComposer();
        public EgoBoostMessage inspiringMessage = new EgoBoostMessage();
        private Encryption Encryption = new Encryption();
        public ObservableCollection<Users> Users { get; set; } = new ObservableCollection<Users>();
        




        public bool IsEmailValid(string emailAddress)
        {
            return inboxManager.ValidateEmailFormat(emailAddress);
        }

        public void GetUserEmails()
        {
            try
            {
                inboxManager.StartGettinMessages();
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
