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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            txtBoxLogin.Text = "admin";
            txtBoxPassword.Text = "admin";
            txtPassword.Password = "admin";
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            {
                int counter = 0;
                int userId = 0;
                var userAuth = new LoginHistory();
                foreach (var user in AcademicEntitiesControl.getContext().Users)
                {
                    counter++;
                    if (txtBoxLogin.Text == user.Login && (txtBoxPassword.Text == user.Password || txtPassword.Password == user.Password))
                     {
                        counter = 0;

                        userAuth.Date = DateTime.Now;
                        userAuth.Status = "Успешно";
                        userAuth.UserID = user.ID;
                        Manager.userRole = user.Role.Name;
                        Manager.userName = user.FirstName;
                        Manager.userSurname = user.LastName;



                        PrimeWindow mainWindow = new PrimeWindow();
                        MessageBox.Show("Вы успешно авторизовались!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                        mainWindow.Show();

                        break;
                    }
                    if (txtBoxLogin.Text == user.Login)
                    {
                        userId = user.ID;
                    }
                }
                if (counter == 0)
                {
                    try
                    {
                        AcademicEntitiesControl.getContext().LoginHistory.Add(userAuth);
                        AcademicEntitiesControl.getContext().SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                if (counter != 0)
                {
                    MessageBox.Show("Вы ввели некорректные данные", "Информация", MessageBoxButton.OK, MessageBoxImage.Error);

                    if (txtBoxLogin.Text != "")
                    {
                        try
                        {
                            if (userId != 0)
                            {
                                userAuth.Date = DateTime.Now;
                                userAuth.Status = "Не успешно";
                                userAuth.UserID = userId;

                                AcademicEntitiesControl.getContext().LoginHistory.Add(userAuth);
                                AcademicEntitiesControl.getContext().SaveChanges();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                    

                }
            }
        }

        private void checkBoxPassword_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxPassword.IsChecked.Value)
            {
                txtBoxPassword.Text = txtPassword.Password;
                txtBoxPassword.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtPassword.Password = txtBoxPassword.Text;
                txtBoxPassword.Visibility = Visibility.Collapsed;
                txtPassword.Visibility = Visibility.Visible;
            }
        }
    }
}

