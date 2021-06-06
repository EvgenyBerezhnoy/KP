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
    /// Логика взаимодействия для ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {
        private void Update()
        {
            if (comboFilter.SelectedItem != null)
            {
                Subject subject = (Subject) comboFilter.SelectedItem;
                List<Rate> currentRates = AcademicEntitiesControl.getContext().Rate.ToList();
                currentRates = currentRates.Where(p => (p.Students.LastName.ToLower().Contains(txtBoxSearchStud.Text.ToLower()) || p.Students.FirstName.ToLower().Contains(txtBoxSearchStud.Text.ToLower()) || p.Subject.SubjectName.ToLower().Contains(txtBoxSearchStud.Text.ToLower()) || p.Students.Groups.GroupNumber.ToLower().Contains(txtBoxSearchStud.Text.ToLower())) && p.SubjectCode == subject.SubjectCode).ToList();
                DGridReport.ItemsSource = currentRates.ToList();
                return;
            }
            List<Rate> currentRate = AcademicEntitiesControl.getContext().Rate.ToList();
            currentRate = currentRate.Where(p => p.Students.LastName.ToLower().Contains(txtBoxSearchStud.Text.ToLower()) || p.Students.FirstName.ToLower().Contains(txtBoxSearchStud.Text.ToLower()) || p.Subject.SubjectName.ToLower().Contains(txtBoxSearchStud.Text.ToLower()) || p.Students.Groups.GroupNumber.ToLower().Contains(txtBoxSearchStud.Text.ToLower())).ToList();
            DGridReport.ItemsSource = currentRate.ToList();
        }
        public ReportsPage()
        {
            InitializeComponent();
            DGridReport.ItemsSource = AcademicEntitiesControl.getContext().Rate.ToList();
            comboFilter.ItemsSource = AcademicEntitiesControl.getContext().Subject.ToList();
        }

        private void comboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void txtBoxSearchStud_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                DGridReport.Measure(pageSize);
                DGridReport.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(DGridReport, Title);
            }
        }
    }
}
