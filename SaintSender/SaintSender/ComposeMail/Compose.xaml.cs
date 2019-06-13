using MimeKit;
using SaintSender.ViewModels;
using System;
using System.Windows;

namespace SaintSender.ComposeMail
{
    /// <summary>
    /// Interaction logic for ComposeMail.xaml
    /// </summary>
    public partial class Compose : Window
    {
        MainViewModel _mvm;
        public Compose(MainViewModel mvm)
        {
            InitializeComponent();
            _mvm = mvm;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            var message = new MimeMessage();
            message = _mvm.EmailComposer.ConstructMessage(emailRecipient.Text, emailSubject.Text, emailBody.Text);
            _mvm.EmailComposer.ConstructAndSendMessage(message);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
