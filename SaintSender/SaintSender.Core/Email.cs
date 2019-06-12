using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MailKit.Security;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace SaintSender.Core
{
    public class Email
    {
        public async void ConstructAndSendMessage(MimeMessage message)
        {
            await Task.Factory.StartNew(SendMessage, message);
        }

        public MimeMessage GetMessageData()
        {
            var message = new MimeMessage();

            Console.WriteLine("Sender name:");
            var senderName = Console.ReadLine();
            message.From.Add(new MailboxAddress(senderName, "saintsender2.0@gmail.com"));

            Console.WriteLine("Recipent Name:");
            var recipentName = Console.ReadLine();
            Console.WriteLine("Recipent e-mail:");
            var recipentEmail = Console.ReadLine();
            message.To.Add(new MailboxAddress(recipentName, recipentEmail));

            Console.WriteLine("Subject:");
            message.Subject = Console.ReadLine();

            var builder = new BodyBuilder();
            Console.WriteLine("E-mail text:");
            builder.TextBody = Console.ReadLine();
            message.Body = builder.ToMessageBody();

            return message;
        }


        public void SendMessage(Object state)
        {
            var message = (MimeMessage)state;
            try
            {
                var client = new SmtpClient();

                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("saintsender2.0@gmail.com", "atssddvndnffxggx");
                client.Send(message);
                client.Disconnect(true);

                Console.WriteLine("Send Mail Success.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Send Mail Failed : " + e.Message);
            }

            Console.ReadLine();
        }
}
