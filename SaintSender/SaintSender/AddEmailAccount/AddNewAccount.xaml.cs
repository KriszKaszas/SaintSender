using SaintSender.Core;
using SaintSender.ViewModels;
using System;
using System.Windows;

namespace SaintSender.AddEmailAccount
{
    /// <summary>
    /// Interaction logic for AddNewAccount.xaml
    /// </summary>
    public partial class AddNewAccount : Window
    {
        private MainViewModel _mvm;
        public AddNewAccount(MainViewModel mvm)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _mvm = mvm;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int portInteger = Int32.Parse(port.Text);
            var newAccount = new EmailAccount(IMAPServer.Text, portInteger, emailAddress.Text, applicationPassword.Text);
            _mvm.Users.CurrentUser.AddAccount(newAccount);
            _mvm.Users.CurrentUser.CurrentEmailAccount = newAccount;
            MessageBox.Show("Account successfully added");
            DialogResult = true;
        }
    }
}
