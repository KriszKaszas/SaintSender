using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core
{
    class Inbox
    {
        
        //private Timer _timer;

        //public Inbox()
        //{
        //    _timer = new Timer(new TimerCallback(GetMessages), null, 0, 2000);
        //}

        //private async void GetMessages(object item)
        //    {
        //        var messages = await Task<List<MimeMessage>>.Factory.StartNew(DownloadMessages);
        //        foreach (var message in messages)
        //        {
        //            Console.WriteLine(message.Subject);
        //        }
        //    }

        //    private List<MimeMessage> DownloadMessages()
        //    {
        //        var messages = new List<MimeMessage>();
        //        using (var client = new ImapClient())
        //        {
        //            client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
        //            client.Authenticate("saintsender2.0@gmail.com", "atssddvndnffxggx");
        //            client.Inbox.Open(FolderAccess.ReadOnly);
        //            var uids = client.Inbox.Search(SearchQuery.All);
        //            foreach (var uid in uids)
        //            {
        //                messages.Add(client.Inbox.GetMessage(uid));
        //            }
        //            client.Disconnect(true);
        //        return messages;
        //        }
        //    }

        
        }
    }
   
}
