using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MTMateoShkurti
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginWin : Window
    {
        private Dictionary <string,Login> userList= new Dictionary<string, Login>();
        public LoginWin()
        {
           
            InitializeComponent();
            userList.Add("admin", new Login(1, "admin", "admin"));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            if (txtUserename.Text==userList["admin"].Username && txtPassword.Password== userList["admin"].Password)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();    // close the LoginWindow
            }
            else
                MessageBox.Show("Either username or password is incorrect", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
    }