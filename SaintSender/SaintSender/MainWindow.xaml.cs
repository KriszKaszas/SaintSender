using SaintSender.ViewModels;
using System.Windows;
using SaintSender.ComposeMail;
using SaintSender.Core;
using System.Collections.Generic;
using MailKit;
using System.Windows.Input;
using SaintSender.ViewMessage;
using System.Windows.Controls;

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

        void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var src = (TextBlock)e.OriginalSource;
            var selectedItem = (ReceivedEmail)src.DataContext;
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

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EgoBoost_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_mvm.InspiringMessage.ChooseRandomMessage());
        }
    }
}
