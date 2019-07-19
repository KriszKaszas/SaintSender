using MailKit;
using System.Collections.Generic;

namespace SaintSender.Core
{
    public struct DeleteMessageData
    {
        public List<UniqueId> uids;
        public EmailAccount currentAccount;

        public DeleteMessageData(List<UniqueId> uids, EmailAccount currentAccount)
        {
            this.uids = uids;
            this.currentAccount = currentAccount;
        }
    }
}