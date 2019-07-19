using SaintSender.Core;
using SaintSender.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SaintSender.AddUser
{
    /// <summary>
    /// Interaction logic for AddNewUser.xaml
    /// </summary>
    public partial class AddNewUser : Window
    {
        private MainViewModel _mvm;
        public AddNewUser(MainViewModel mvm)
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
            if(password.Text == confirmPassword.Text)
            {
                var newUser = new User(name.Text, _mvm.encryption.Hash(password.Text));
                _mvm.AddNewUser(newUser);
                MessageBox.Show("New user successfuly added!");
                Close();
            }
            else
            {
                MessageBox.Show("Passwords don't match!");
                password.Clear();
                confirmPassword.Clear();
            }
        }
    }
}
