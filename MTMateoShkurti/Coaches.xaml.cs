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
    /// Interaction logic for Coaches.xaml
    /// </summary>
    public partial class Coaches : Window
    {
        List<Coach> coachList;
        public Coaches()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            coachList = new List<Coach>();
            coachList.Add(new Coach(0,"Stefano Pioli", 7, 309, 65, 17));
            coachList.Add(new Coach(1, "Zinedine Zidane", 1, 40, 80, 6));
            coachList.Add(new Coach(2, "Ole Solskjaer", 1, 39, 63, 2));
            coachList.Add(new Coach(3,"Jurgen Klopp",4,307,78,20));
            coachList.Add(new Coach(4, "Jose Mourinho", 10, 567, 69, 19));

            listRefresh();
          
        }
        public void listRefresh()
        {
            var names = from c in coachList
                        select c.Name;
            listBoxCoach.ItemsSource = names;
        }
        private void listBoxCoach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = listBoxCoach.SelectedIndex;

            var selectedCoach = (from c in coachList
                                 where c.Id == index
                                 select c).FirstOrDefault();

            txtName.Text = selectedCoach.Name;
            txtNTC.Text = selectedCoach.NumberOfTeamsCoached.ToString();
            txtPT.Text = selectedCoach.PlayersTrained.ToString();
            txtWP.Text = selectedCoach.WinPercentage.ToString();
            txtYoE.Text = selectedCoach.YearsOfExperience.ToString();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validateTextbox() == 1)
            {
                coachList.Add(new Coach(coachList.Last().Id + 1, txtName.Text, int.Parse(txtNTC.Text), int.Parse(txtPT.Text), double.Parse(txtWP.Text), int.Parse(txtYoE.Text)));
                listRefresh();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to Update data?", "UPDATE?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                if (validateIndex() == 1 && validateTextbox() == 1)
                {
                    var index = listBoxCoach.SelectedIndex;
                    var coach = coachList[index];

                    coach.Name = txtName.Text;
                    coach.NumberOfTeamsCoached = int.Parse(txtNTC.Text);
                    coach.PlayersTrained = int.Parse(txtPT.Text);
                    coach.WinPercentage = double.Parse(txtWP.Text);
                    coach.YearsOfExperience = int.Parse(txtYoE.Text);
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
                    var index = listBoxCoach.SelectedIndex;
                    coachList.RemoveAt(index);
                    listRefresh();
                }
            }

        }

       
        public int validateTextbox()
        {



            if (txtName.Text.Length < 1 || txtNTC.Text.Length < 1 || txtPT.Text.Length < 1 || txtWP.Text.Length < 1 || txtYoE.Text.Length < 1)
            {
                MessageBox.Show("Some Boxes are Empty", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }



            try { int.Parse(txtYoE.Text); }
            catch (Exception e)
            {
                MessageBox.Show("No letters allowed!", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            try { int.Parse(txtPT.Text); }
            catch (Exception e)
            {
                MessageBox.Show("No letters allowed!", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            try { int.Parse(txtNTC.Text); }
            catch (Exception e)
            {
                MessageBox.Show("No letters allowed!", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            try { double.Parse(txtWP.Text); }
            catch (Exception e)
            {
                MessageBox.Show("No letters allowed!", "Check Your Entries", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }


            return 1;
        }

        public int validateIndex()
        {
            if (listBoxCoach.SelectedIndex < 0)
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
