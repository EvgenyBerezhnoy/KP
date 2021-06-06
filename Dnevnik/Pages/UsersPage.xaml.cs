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

namespace Dnevnik
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
       
        private static Users _currentusers;
        public UsersPage()
        {
            InitializeComponent();
            Role.ItemsSource = AcademicEntitiesControl.getContext().Role.ToList();
        }

        private void Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAddUsers_Click(object sender, RoutedEventArgs e)
        {
            _currentusers = new Users();
            StringBuilder errors = new StringBuilder();
            if (txtLast.Text == "")
            {
                errors.AppendLine("Вы не вписали фамилию");
            }
            if (txtFirst.Text == "")
            {
                errors.AppendLine("Вы не ввели имя");
            }

            if (Role.SelectedItem == null)
            {
                errors.AppendLine("Вы не выбрали группу");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            
            else
            {
                _currentusers.LastName = txtLast.Text;
                _currentusers.FirstName = txtFirst.Text;
                _currentusers.Login = txtLogin.Text;
                _currentusers.Password = txtPassword.Text;
                Data.Role selectedRole = (Data.Role)Role.SelectedItem;
                _currentusers.RoleId = selectedRole.ID;
            }
            try
            {
                    AcademicEntitiesControl.getContext().Users.Add(_currentusers);
                    AcademicEntitiesControl.getContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
                Manager.MainFrame.GoBack();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
