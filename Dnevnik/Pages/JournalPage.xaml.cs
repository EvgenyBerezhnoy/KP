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
    /// Логика взаимодействия для JournalPage.xaml
    /// </summary>
    public partial class JournalPage : Page
    {
        public JournalPage()
        {
            InitializeComponent();
            DGridJournal.ItemsSource = AcademicEntitiesControl.getContext().Rate.ToList();
            
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ResultsAdd((sender as Button).DataContext as Rate));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                AcademicEntitiesControl.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
     
                DGridJournal.ItemsSource = AcademicEntitiesControl.getContext().Rate.ToList();
            }

        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            var ratesForRemoving = DGridJournal.SelectedItems.Cast<Rate>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {ratesForRemoving.Count()} элементов?","Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes )
            {
                try
                {
                    AcademicEntitiesControl.getContext().Rate.RemoveRange(ratesForRemoving);
                    AcademicEntitiesControl.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridJournal.ItemsSource = AcademicEntitiesControl.getContext().Rate.ToList();
                }
            catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
