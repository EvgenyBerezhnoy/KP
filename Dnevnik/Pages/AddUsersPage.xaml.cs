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
using Dnevnik.Data;

namespace Dnevnik.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddUsersPage.xaml
    /// </summary>
    public partial class AddUsersPage : Page
    {
        public AddUsersPage()
        {
            InitializeComponent();
            DGridAddUsers.ItemsSource = AcademicEntitiesControl.getContext().Users.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AcademicEntitiesControl.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());

                DGridAddUsers.ItemsSource = AcademicEntitiesControl.getContext().Users.ToList();
            }

        }

        private void btnAddUsers_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UsersPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var StudentsRemove = DGridAddUsers.SelectedItems.Cast<Users>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {StudentsRemove.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AcademicEntitiesControl.getContext().Users.RemoveRange(StudentsRemove);
                    AcademicEntitiesControl.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridAddUsers.ItemsSource = AcademicEntitiesControl.getContext().Users.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }
    }
}
