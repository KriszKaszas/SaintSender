using MimeKit;
using SaintSender.ViewModels;
using System.Windows;

namespace SaintSender.ComposeMail
{
    /// <summary>
    /// Interaction logic for ComposeMail.xaml
    /// </summary>
    public partial class Compose : Window
    {
        private MainViewModel _mvm;
              
        public Compose(MainViewModel mvm, string emailAddress = null, string Subject = null)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _mvm = mvm;
            emailRecipient.Text = emailAddress;
            emailSubject.Text = Subject;

        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            var message = new MimeMessage();
            message = _mvm.emailComposer.ConstructMessage(emailRecipient.Text, emailSubject.Text, emailBody.Text);
            _mvm.emailComposer.ConstructAndSendMessage(message);
            MessageBox.Show("Your E-mail Has Been Sent!");
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
