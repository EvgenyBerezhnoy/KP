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

namespace Dnevnik
{
    /// <summary>
    /// Логика взаимодействия для ResultsAdd.xaml
    /// </summary>
    public partial class ResultsAdd : Page
    {

        private static Rate _curentrate;
        public ResultsAdd(Rate selectedrate)
        {
            InitializeComponent();
            StudLast.ItemsSource = AcademicEntitiesControl.getContext().Students.ToList();
            GroupName.ItemsSource = AcademicEntitiesControl.getContext().Groups.ToList();
            StudFirst.ItemsSource = AcademicEntitiesControl.getContext().Students.ToList();
            Subject.ItemsSource = AcademicEntitiesControl.getContext().Subject.ToList();
            _curentrate = new Rate();
            if (selectedrate != null)
                _curentrate = selectedrate;
            DataContext = _curentrate;
        }

        private void StudFirst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StudFirst.ItemsSource != null)
            {
                Students students = (Students)StudFirst.SelectedItem;
                StudLast.ItemsSource = AcademicEntitiesControl.getContext().Students.Where(p => p.GroupCode == students.GroupCode && p.LastName == students.LastName).ToList();
            }

            
        }

        private void GroupName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Groups groups = (Groups)GroupName.SelectedItem;

                StudFirst.ItemsSource = null;
                StudLast.ItemsSource = null;
                StudLast.ItemsSource = AcademicEntitiesControl.getContext().Students.Where(p => p.GroupCode == groups.GroupCode).ToList();
                StudFirst.ItemsSource = AcademicEntitiesControl.getContext().Students.Where(p => p.GroupCode == groups.GroupCode).ToList();

        }

        private void StudLast_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         if(StudLast.ItemsSource!= null)
            {
                Students students = (Students)StudLast.SelectedItem;
                StudFirst.ItemsSource = null;
                StudFirst.ItemsSource = AcademicEntitiesControl.getContext().Students.Where(p => p.GroupCode == students.GroupCode && p.LastName == students.LastName).ToList();
            }


            
            
        }

        private void Subject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddResult_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (GroupName.SelectedItem == null)
            {
                errors.AppendLine("Вы не выбрали группу");
            }
            if (StudLast.SelectedItem == null)
            {
                errors.AppendLine("Вы не выбрали фамилию");
            }
            if (StudFirst.SelectedItem == null)
            {
                errors.AppendLine("Вы не выбрали имя");
            }
            if (Subject.SelectedItem == null)
            {
                errors.AppendLine("Вы не выбрали предмет");
            }
            if (rate.Text == "")
            {
                errors.AppendLine("Вы не ввели оценку");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return; 
            }
            try
            {
                Students students = (Students)StudFirst.SelectedItem;
                _curentrate.StudentCode = students.StudentCode;
                Subject subject = (Subject)Subject.SelectedItem;
                _curentrate.SubjectCode = subject.SubjectCode;
                _curentrate.Mark = Convert.ToInt32(rate.Text);
                AcademicEntitiesControl.getContext().Database.ExecuteSqlCommand($"INSERT INTO Rate VALUES ({_curentrate.SubjectCode}, {_curentrate.StudentCode}, {_curentrate.Mark})");
                MessageBox.Show("Оценка выставлена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }

       
        
          

        
    }
}
