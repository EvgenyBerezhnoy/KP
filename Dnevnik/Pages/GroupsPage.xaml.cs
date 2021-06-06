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
    /// Логика взаимодействия для GroupsPage.xaml
    /// </summary>
    public partial class GroupsPage : Page
    {
        public GroupsPage()
        {
            InitializeComponent();
        }

        private void Update()
        {
            DGridGroups.ItemsSource = AcademicEntitiesControl.getContext().Students.ToList().Where(p => p.LastName.ToLower().Contains(txtBoxSearchStud.Text.ToLower())).ToList();
           
        }

        private void StudAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddStudentsPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AcademicEntitiesControl.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridGroups.ItemsSource = AcademicEntitiesControl.getContext().Students.ToList();
            }
        }

        private void StudDelete_Click(object sender, RoutedEventArgs e)
        {
            var StudentsRemove = DGridGroups.SelectedItems.Cast<Students>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {StudentsRemove.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AcademicEntitiesControl.getContext().Students.RemoveRange(StudentsRemove);
                    AcademicEntitiesControl.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridGroups.ItemsSource = AcademicEntitiesControl.getContext().Students.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddStudentsPage((sender as Button).DataContext as Students));
            

        }

        

        

        private void txtBoxSearchStud_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
