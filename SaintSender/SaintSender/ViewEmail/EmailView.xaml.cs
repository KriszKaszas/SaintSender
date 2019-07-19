using MailKit;
using SaintSender.Core;
using SaintSender.ViewModels;
using SaintSender.ComposeMail;
using System.Collections.Generic;
using System.Windows;
using System.Text.RegularExpressions;

namespace SaintSender.ViewMessage
{
    /// <summary>
    /// Interaction logic for EmailView.xaml
    /// </summary>
    public partial class EmailView : Window
    {
        private MainViewModel _mvm;
        private List<UniqueId> _emailId = new List<UniqueId>(); 
        public EmailView(ReceivedEmail email, MainViewModel mvm)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _mvm = mvm;
            _emailId.Add(email.Uid);;
            emailSender.Text = email.EmailAddress;
            emailSubject.Text = email.Subject;
            emailBody.Text = email.Body;

        }

        private string ExtractEmail()
        {
            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
                 RegexOptions.IgnoreCase);
            Match match = emailRegex.Match(emailSender.Text);
            return match.Value;
        }

        private void ReplyButton_Click(object sender, RoutedEventArgs e)
        {

            var Compose = new Compose(_mvm, ExtractEmail(), $"Re: {emailSubject.Text}");
            Compose.Show();
            Close();

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            _mvm.inboxManager.DeleteMessagesAsync(new DeleteMessageData(_emailId, _mvm.Users.CurrentUser.CurrentEmailAccount));
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
