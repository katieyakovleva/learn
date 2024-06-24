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

namespace learn.papka
{
    /// <summary>
    /// Логика взаимодействия для TimeSheetPage.xaml
    /// </summary>
    public partial class TimeSheetPage : Page
    {
        public static DateTime? SelectedDate { get; internal set; }

        public TimeSheetPage()
        {
            InitializeComponent();
        }

      

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TimeSheetAdd((sender as Button).DataContext as uslugi_client));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TimeSheetAdd(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
           var selectedVisits = DataGridVisits.SelectedItems.Cast<uslugi_client>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedVisits.Count()} записей???", "Удаление", MessageBoxButton.OKCancel);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    uslugi_client x = selectedVisits[0];
                    uslugiEntities1.GetContext().uslugi_client.Remove(x);
                    uslugiEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Запись удалена");
                    List<uslugi_client> uslugi_Clients = uslugiEntities1.GetContext().uslugi_client.OrderBy(p => p.uslugi).ToList();
                    

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DataGridVisits.ItemsSource = null;
                uslugiEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<uslugi_client> uslugis = uslugiEntities1.GetContext().uslugi_client.OrderBy(p => p.код_оказания_услуги).ToList();
                DataGridVisits.ItemsSource = uslugis;
            }
        }

        private void DataGridVisits_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
