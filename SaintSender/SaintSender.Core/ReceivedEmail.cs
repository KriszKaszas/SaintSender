using MailKit;
using MimeKit;
using System;

namespace SaintSender.Core
{
    public class ReceivedEmail : IEquatable<ReceivedEmail>
    {
        public UniqueId Uid { get; set; }
        public string EmailId { get; set; }
        public DateTimeOffset EmailDate { get; set; }
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }


        public ReceivedEmail(UniqueId uid, MimeMessage message)
        {
            Uid = uid;
            EmailId = message.MessageId;
            EmailDate = message.Date;
            EmailAddress = message.From.ToString();
            Subject = message.Subject;
            Body = message.TextBody;
        }

        public override string ToString()
        {
            return $"From: {EmailAddress} \n Subject: {Subject} \n Date: {EmailDate}";
        }

        public bool Equals(ReceivedEmail other)
        {
            return EmailId == other.EmailId;
        }
    }
}
