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
        public Encryption encryption = new Encryption();

        public Users Users { get; } = new Users();

        public bool IsEmailValid(string emailAddress)
        {
            return inboxManager.ValidateEmailFormat(emailAddress);
        }
        
        public void GetUserEmails(EmailAccount currentAccount)
        {
            inboxManager.StartGettinMessages(currentAccount);
        }

        public void AddNewUser(User user)
        {
            Users.AddUser(user);
            Users.CurrentUser = user;
        }
    }
}
