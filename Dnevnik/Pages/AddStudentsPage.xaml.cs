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
using Dnevnik.Properties;
using Dnevnik.Pages;


namespace Dnevnik.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddStudentsPage.xaml
    /// </summary>
    public partial class AddStudentsPage : Page
    {
        private static Students _currentstudents;
        public AddStudentsPage(Students selectedStudent)
        {
            InitializeComponent();
            _currentstudents = new Students();
            if (selectedStudent != null)
            _currentstudents = selectedStudent;
            GroupAdd.ItemsSource = AcademicEntitiesControl.getContext().Groups.ToList();
            DataContext = _currentstudents;
        }

        private void GroupAdd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void addStud_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (lastName.Text== "")
            {
                errors.AppendLine("Вы не вписали фамилию");
            }
            if (FirstName.Text == "")
            {
                errors.AppendLine("Вы не ввели имя");
            }
            
            if (GroupAdd.SelectedItem == null)
            {
                errors.AppendLine("Вы не выбрали группу");
            }
            
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (GroupAdd.SelectedItem != null)
            {
                _currentstudents.GroupCode = (GroupAdd.SelectedItem as Groups).GroupCode;
            }
            if (_currentstudents.StudentCode == 0)
               AcademicEntitiesControl.getContext().Students.Add(_currentstudents);
            try
            {
                AcademicEntitiesControl.getContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
                Manager.MainFrame.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void CardNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
