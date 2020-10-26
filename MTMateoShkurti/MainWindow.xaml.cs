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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MTMateoShkurti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void btnManagers_Click(object sender, RoutedEventArgs e)
        {
            Managers managerWin = new Managers();
            managerWin.ShowDialog();
        }

        private void btnPlayer_Click(object sender, RoutedEventArgs e)
        {
            Players playerWin = new Players();
            playerWin.ShowDialog();

        }

        private void btnCoaches_Click(object sender, RoutedEventArgs e)
        {
            Coaches coachWin = new Coaches();
            coachWin.ShowDialog();
        }

        private void mnuPlayer_Click(object sender, RoutedEventArgs e)
        {
            btnPlayer_Click(sender, e);
        }

        private void mnuCoach_Click(object sender, RoutedEventArgs e)
        {
            btnCoaches_Click(sender, e);
        }

        private void mnuManager_Click(object sender, RoutedEventArgs e)
        {
            btnManagers_Click(sender, e);
        }
    }
}
