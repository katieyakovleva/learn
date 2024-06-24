using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для GoodPage.xaml
    /// </summary>
    public partial class GoodPage : Page
    {
        

        public GoodPage()
        {
            InitializeComponent();
           
        }

        //public GoodPage()
        //{
        //}

        private void DataUslugi_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GoodAddPage((sender as Button).DataContext as uslugi));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DataUslugi.ItemsSource = null;
                uslugiEntities1.GetContext().ChangeTracker.Entries().ToList(). ForEach(p => p.Reload());
                List<uslugi> uslugis = uslugiEntities1.GetContext().uslugis.OrderBy(p => p.Наименование_услуги).ToList();
                DataUslugi.ItemsSource = uslugis;
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedusugi = DataUslugi.SelectedItems.Cast<uslugi>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить{selectedusugi.Count()} записей???", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.OK);

            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    uslugi x = selectedusugi[0];
                    uslugiEntities1.GetContext().uslugis.Remove(x);
                    uslugiEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<uslugi> uslugis = uslugiEntities1.GetContext().uslugis.OrderBy(p => p.Наименование_услуги).ToList();
                    DataUslugi.ItemsSource = null;
                    DataUslugi.ItemsSource = uslugis;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnEdit_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GoodAddPage((sender as Button).DataContext as uslugi));
        }
    }
}
