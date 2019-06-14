using SaintSender.ViewModels;
using System.Windows;
using SaintSender.ComposeMail;
using SaintSender.Core;
using System.Collections.Generic;
using MailKit;
using System.Windows.Input;
using SaintSender.ViewMessage;

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

        void lbi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (ReceivedEmail)listEmails.SelectedItem;
            EmailView view = new EmailView(selectedItem, _mvm);
            view.Show();
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
