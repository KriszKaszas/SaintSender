using SaintSender.Core;
using System;
using MailKit.Security;


namespace SaintSender.ViewModels
{
    public class MainViewModel
    {
        public InboxManager InboxManager { get; set; } = new InboxManager();
        public EmailComposer EmailComposer { get; set; } = new EmailComposer();
        public EgoBoostMessage InspiringMessage { get; set; } = new EgoBoostMessage();


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
