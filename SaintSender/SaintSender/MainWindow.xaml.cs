using SaintSender.ViewModels;
using System.Windows;
using SaintSender.ComposeMail;
using System.Windows.Controls;
using SaintSender.Core;
using System.Collections.Generic;
using MailKit;

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
            _mvm.GetUserEmails();
            listEmails.ItemsSource = _mvm.InboxManager.ReceivedEmails;
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
            _mvm.InboxManager.DeleteMessages(toDelete);
        }
    }
}
