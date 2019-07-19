using System.Windows;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Controls;
using System;
using MailKit;
using SaintSender.Core;
using SaintSender.ViewModels;
using SaintSender.ViewMessage;
using SaintSender.ComposeMail;
using SaintSender.AddEmailAccount;
using SaintSender.AddUser;
using SaintSender.Login;

namespace SaintSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mvm = new MainViewModel();
        
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //if ( _mvm.users.CurrentUser != null && _mvm.users.CurrentUser.CurrentEmailAccount != null)
            //{
            //    _mvm.GetUserEmails(_mvm.users.CurrentUser.CurrentEmailAccount);
            //    listEmails.ItemsSource = _mvm.inboxManager.ReceivedEmails;
            //}
        }

        void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var src = (TextBlock)e.OriginalSource;
                var selectedItem = (ReceivedEmail)src.DataContext;
                EmailView view = new EmailView(selectedItem, _mvm);
                view.Show();
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Invalid double click area");
            }
        }

        private void Compose_Click(object sender, RoutedEventArgs e)
        {
            var Compose = new Compose(_mvm);
            Compose.Show();
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var toDelete = new List<UniqueId>();
            var selectedItems = listEmails.SelectedItems;
            foreach (var item in selectedItems)
            {
                toDelete.Add(((ReceivedEmail)item).Uid);
            }
            _mvm.inboxManager.DeleteMessagesAsync(new DeleteMessageData(toDelete, _mvm.users.CurrentUser.CurrentEmailAccount));
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EgoBoost_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_mvm.inspiringMessage.ChooseRandomMessage());
        }

        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            var addNewAccount = new AddNewAccount(_mvm);
            if (addNewAccount.ShowDialog() == true)
            {
                _mvm.GetUserEmails(_mvm.users.CurrentUser.CurrentEmailAccount);
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var addNewUser = new AddNewUser(_mvm);
            addNewUser.Show();
        }


        private void SwitchUser_Click(object sender, RoutedEventArgs e)
        {
            var login = new UserLogin(_mvm);
            login.Show();
        }

    }
}
