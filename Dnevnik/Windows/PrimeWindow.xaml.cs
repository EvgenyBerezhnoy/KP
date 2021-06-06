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
using Dnevnik.Data;


namespace Dnevnik.Pages
{
    /// <summary>
    /// Логика взаимодействия для PrimeWindow.xaml
    /// </summary>
    public partial class PrimeWindow : Window
    {
        public PrimeWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            BtnBack.Visibility = Visibility.Collapsed;
            txtFirstName.Text = Manager.userName + " ";
            txtLastName.Text = Manager.userSurname;
            
            if (Manager.userRole == "Teacher")
            {
                BtnGroups.Visibility = Visibility.Collapsed;
                BtnHistory.Visibility = Visibility.Collapsed;
                BtnJournal.Visibility = Visibility.Visible;
                BtnReports.Visibility = Visibility.Visible;
                btnAddUsers.Visibility = Visibility.Collapsed;
            }
            if (Manager.userRole == "Dean")
            {
                BtnGroups.Visibility = Visibility.Visible;
                BtnHistory.Visibility = Visibility.Collapsed;
                BtnJournal.Visibility = Visibility.Collapsed;
                BtnReports.Visibility = Visibility.Visible;
                btnAddUsers.Visibility = Visibility.Collapsed;
            }

        }

        private void BtnReports_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportsPage());
        }

        private void BtnJournal_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new JournalPage());
        }

        private void BtnGroups_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GroupsPage());
        }

        private void BtnHistory_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HistoryPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (Manager.MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }

        }

        private void btnAddUsers_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddUsersPage());
        }
    }
}
