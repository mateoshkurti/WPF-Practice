using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Players.xaml
    /// </summary>
    public partial class Players : Window
    {
        List<Player> playerList;
        public Players()
        {
            InitializeComponent();
           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            playerList = new List<Player>();
            playerList.Add(new Player(0, "Lionel Messi", 789, 548, 123, 704));
            playerList.Add(new Player(1, "Cristiano Ronaldo", 890, 678, 125, 764));
            playerList.Add(new Player(2, "Zlatan Ibrahimovic", 689, 490, 103, 549));
            playerList.Add(new Player(3, "Ricardo Kaka", 430, 329, 78, 134));
            playerList.Add(new Player(4, "Andry Shevchenko", 560, 407, 129, 389));

            listRefresh();
        }

        private void listBoxPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listBoxPlayer.SelectedIndex;

            var selectedPlayer = (from player in playerList
                            where player.Id == index
                            select player).FirstOrDefault();

            if (selectedPlayer != null)
            {
                txtName.Text = selectedPlayer.Name;
                txtMP.Text = selectedPlayer.MatchesPlayed.ToString();
                txtMW.Text = selectedPlayer.Won.ToString();
                txtML.Text = selectedPlayer.Lost.ToString();
                txtGS.Text = selectedPlayer.GoalsScored.ToString();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validateTextBox() == 1)
            {
                playerList.Add(new Player(playerList.Last().Id+1, txtName.Text, int.Parse(txtMP.Text), int.Parse(txtMW.Text), int.Parse(txtML.Text), int.Parse(txtGS.Text)));
                listRefresh();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to Update data?", "UPDATE?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                if (validateTextBox() == 1 && validateIndex() == 1)
                {
                    int index = listBoxPlayer.SelectedIndex;

                    var selected = playerList[index];

                    selected.Name = txtName.Text;
                    selected.MatchesPlayed = int.Parse(txtMP.Text);
                    selected.Won = int.Parse(txtMW.Text);
                    selected.GoalsScored = int.Parse(txtGS.Text);
                    selected.Lost = int.Parse(txtML.Text);

                    listRefresh();
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to Delete data?", "DELETE?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                if (validateIndex() == 1)
                {
                    int index = listBoxPlayer.SelectedIndex;

                    playerList.RemoveAt(index);
                    listRefresh();
                }
            }
        }

        public void listRefresh() {
            var names = from player in playerList
                        select player.Name;
            listBoxPlayer.ItemsSource = names;
        }

        private void mnuAdd_Click(object sender, RoutedEventArgs e)
        {
            btnAdd_Click(sender, e);
        }

        private void mnuUpdate_Click(object sender, RoutedEventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void mnuDelete_Click(object sender, RoutedEventArgs e)
        {
            btnDelete_Click(sender, e);
        }

        private int validateTextBox() {
            

            
            if (txtName.Text.Length < 1 || txtMW.Text.Length<1|| txtMP.Text.Length<1|| txtML.Text.Length<1 || txtGS.Text.Length<1)
            {
                MessageBox.Show("Some Boxes are Empty", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

               
               
                try { int.Parse(txtGS.Text); }
                catch (Exception e) {
                    MessageBox.Show("No letters allowed!", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 0; }

                try { int.Parse(txtMP.Text); }
                catch (Exception e)
                {
                    MessageBox.Show("No letters allowed!", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 0;
                }

                try { int.Parse(txtMW.Text); }
                catch (Exception e)
                {
                    MessageBox.Show("No letters allowed!", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 0;
                }

                try { int.Parse(txtML.Text); }
                catch (Exception e)
                {
                    MessageBox.Show("No letters allowed!", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 0;
                }
            
          
            return 1;
        }

        private int validateIndex()
        {
            if (listBoxPlayer.SelectedIndex < 0)
            {
                MessageBox.Show("No Item Selected", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return 1;
        }
    }
}
