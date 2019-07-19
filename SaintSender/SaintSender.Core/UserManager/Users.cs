using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SaintSender.Core
{
    public class Users
    {

        public User CurrentUser { get; set; }
        public ObservableCollection<User> users = new ObservableCollection<User>();

        public void AddUser(User user)
        {
            users.Add(user);
            CurrentUser = user;
        }

        public void AddAccountToUser(EmailAccount newAccount)
        {
            CurrentUser.AddAccount(newAccount);
        }

        public void DeleteAccount(EmailAccount account)
        {
            CurrentUser.accounts.Remove(account);
        }
    }
}
