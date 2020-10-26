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
    /// Interaction logic for Managers.xaml
    /// </summary>
    public partial class Managers : Window
    {
        List<Manager> managerList;
        public Managers()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            managerList = new List<Manager>();
            managerList.Add(new Manager(0,"Jorge Mendes", 189,20000000,"Connections"));
            managerList.Add(new Manager(1, "Mino Raiola", 204, 30000000, "Convincing"));
            managerList.Add(new Manager(2,"Jose Otin",178, 2000000,"Negotiation"));
            managerList.Add(new Manager(3,"SEG",145, 10000000,"Promotion"));
            managerList.Add(new Manager(4,"Jonathan Barnett", 132, 10000000,"Connections"));
            listRefresh();
          
        }

        public void listRefresh()
        {
            var names = from m in managerList
                        select m.Name;
            listBoxManager.ItemsSource = names;
        }

        private void listBoxManager_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = listBoxManager.SelectedIndex;

            var selectedManager = (from m in managerList
                                   where m.Id == index
                                   select m).FirstOrDefault();
            txtName.Text = selectedManager.Name;
            txtStrength.Text = selectedManager.Strength;
            txtPR.Text = selectedManager.PlayersRecruted.ToString();
            txtAB.Text = selectedManager.AvailableBudget.ToString();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validateTextbox() == 1)
            {
                managerList.Add(new Manager(managerList.Last().Id + 1, txtName.Text, int.Parse(txtPR.Text), double.Parse(txtAB.Text), txtStrength.Text));
                listRefresh();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to Update data?", "UPDATE?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                if (validateTextbox() == 1 && validateIndex() == 1)
                {
                    var index = listBoxManager.SelectedIndex;
                    var m = managerList[index];
                    m.Name = txtName.Text;
                    m.Strength = txtStrength.Text;
                    m.PlayersRecruted = int.Parse(txtPR.Text);
                    m.AvailableBudget = double.Parse(txtAB.Text);

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
                    var index = listBoxManager.SelectedIndex;
                    managerList.RemoveAt(index);
                    listRefresh();
                }
            }
        }

        public int validateTextbox()
        {



            if (txtName.Text.Length < 1 || txtAB.Text.Length < 1 || txtPR.Text.Length < 1 || txtStrength.Text.Length < 1)
            {
                MessageBox.Show("Some Boxes are Empty", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }



            try { int.Parse(txtPR.Text); }
            catch (Exception e)
            {
                MessageBox.Show("No letters allowed!", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            try { double.Parse(txtAB.Text); }
            catch (Exception e)
            {
                MessageBox.Show("No letters allowed!", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }


            return 1;
        }

        public int validateIndex()
        {
            if (listBoxManager.SelectedIndex < 0)
            {
                MessageBox.Show("No Item Selected", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return 1;
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
    }
}
