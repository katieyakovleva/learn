using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для TimeSheetAdd.xaml
    /// </summary>
    public partial class TimeSheetAdd : Page
    {
        private client Client;
        private uslugi_client _Visit = new uslugi_client();
        private uslugi_client _currentTimeSheet = new uslugi_client();
        
        
        public TimeSheetAdd(uslugi_client selectedVisits)
        {
            InitializeComponent();
            CmbService.ItemsSource = uslugiEntities1.GetContext().uslugis.OrderBy(p => p.Наименование_услуги).ToList();
            CmbLastName.ItemsSource = uslugiEntities1.GetContext().clients.ToList();
            CmbName.ItemsSource = uslugiEntities1.GetContext().clients.ToList();
            CmbSurName.ItemsSource = uslugiEntities1.GetContext().clients.ToList();
            if (selectedVisits != null)
            {
                TbId.Visibility = Visibility.Hidden;
                _currentTimeSheet= selectedVisits;
                List<client> list = new List<client>();
            }
            DataContext = _Visit;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = TimeSheetPage.SelectedDate;
            MessageBox.Show(selectedDate.Value.ToShortDateString());
        }



        private StringBuilder CheckFileds()
        {
            
            StringBuilder s = new StringBuilder();
            //if (_currentTimeSheet.uslugi.Наименование_услуги == null)
            //    s.AppendLine("Выберите услугу");
            //if (_currentTimeSheet.client.Фамилия == null)
            //    s.AppendLine("Выберите фамилию");
            //if (_currentTimeSheet.client.Имя == null)
            //    s.AppendLine("выберите фото");
            //if (_currentTimeSheet.client.Отчество == null)
            //    s.AppendLine("выберите отчество");
            
            return s;
        }




        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFileds();
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }

            if (_currentTimeSheet.код_услуги == 0)
            {
                uslugiEntities1.GetContext().uslugi_client.Add(_currentTimeSheet);
            }

            try
            {
               uslugiEntities1.GetContext().SaveChanges();
                MessageBox.Show("Запись изменена");
                NavigationService.Navigate(new papka.TimeSheetPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}
