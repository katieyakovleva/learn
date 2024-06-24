
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
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        int _itemcount = 0;
        
        
       
        public CatalogPage(bool b)
        {
            InitializeComponent();
            ListBoxuslugi.ItemsSource = uslugiEntities1.GetContext().uslugis.OrderBy(p => p.Наименование_услуги).ToList();
            _itemcount = ListBoxuslugi.Items.Count;
            TextBlockCount.Text = $" Результат запроса: {_itemcount} записей из {_itemcount}"; 


        }

      

       

       

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void CmbUslugi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }


        private void UpdateData()
        {
            var currentuslugi = uslugiEntities1.GetContext().uslugis.OrderBy(p => p.Наименование_услуги).ToList();
            if (CmbSkidka.SelectedIndex > 0)
            {
                int a = 0;
                int b = 0;
                switch (CmbSkidka.SelectedIndex)
                {
                    case 1:
                        a = 0;
                        b = 5;
                        break;
                    case 2:
                        a = 5;
                        b = 15;
                        break;

                    case 3:
                        a = 15;
                        b = 30;
                        break;

                    case 4:

                        a = 30;
                        b = 70;
                        break;

                    case 5:
                        a = 70;
                        b = 100;
                        break;

                }

                currentuslugi = currentuslugi.Where(p => p.Действующая_скидка >= a && p.Действующая_скидка < b).ToList();
            }

            currentuslugi = currentuslugi.Where(p => p.Наименование_услуги.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if (CmbSort.SelectedIndex >= 0)
            {
                if (CmbSort.SelectedIndex == 0)
                    currentuslugi = currentuslugi.OrderBy(p => p.Стоимость).ToList();


                if (CmbSort.SelectedIndex == 1)
                    currentuslugi = currentuslugi.OrderByDescending(p => p.Стоимость).ToList();
            }

            ListBoxuslugi.ItemsSource = currentuslugi;
            TextBlockCount.Text = $" Результат Запроса: {currentuslugi.Count} записей из {_itemcount}";
        
            

        }

      

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                uslugiEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListBoxuslugi.ItemsSource = uslugiEntities1.GetContext().uslugis.OrderBy(p => p.Наименование_услуги).ToList();
            }
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();

        }

      

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
