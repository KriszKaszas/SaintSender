using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core
{
    public class User
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public EmailAccount CurrentEmailAccount { get; set; }

        public ObservableCollection<EmailAccount> accounts = new ObservableCollection<EmailAccount>();

        public User(string userName, string passwordHash)
        {
            UserName = userName;
            PasswordHash = passwordHash;
        }

        public void AddAccount(EmailAccount newAccount)
        {
            accounts.Add(newAccount);
        }
    }
}