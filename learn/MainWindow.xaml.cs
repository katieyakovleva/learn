using learn.papka;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace learn
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool _admin = false;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new papka.CatalogPage(_admin));



        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (_admin)
            {
                if (MainFrame.CanGoBack)
                {
                    BtnBack.Visibility = Visibility.Visible;
                    BtnAdmin.Visibility = Visibility.Collapsed;
                    BtnServices.Visibility = Visibility.Collapsed;
                    BtnTimeSheet.Visibility = Visibility.Collapsed;
                }

                else
                {
                    BtnBack.Visibility = Visibility.Collapsed;
                    BtnAdmin.Visibility = Visibility.Visible;
                    BtnServices.Visibility = Visibility.Visible;
                    BtnTimeSheet.Visibility = Visibility.Visible;
                }
            }

            else
            {
                BtnBack.Visibility = Visibility.Collapsed;
                BtnAdmin.Visibility = Visibility.Visible;
                BtnServices.Visibility = Visibility.Collapsed;
                BtnTimeSheet.Visibility = Visibility.Collapsed;
            }


        }



        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (_admin)
            {
                MessageBoxResult x = MessageBox.Show("Вы действительно хотите выйти из режима администратора?", "Выйти", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (x == MessageBoxResult.OK)
                {
                    _admin = false;
                    MainFrame.Refresh();
                    return;
                }
            }

            Window1 Pass = new Window1();
            if (Pass.ShowDialog() == true)
            {
                if (Pass.Password == "0000")
                {
                    MessageBox.Show("Авторизация пройдена");
                    _admin = true;
                    MainFrame.Refresh();
                }

                else

                    MessageBox.Show("Неверный пароль");
            }

            else
            {
                MessageBox.Show("Авторизация не пройдена");
            }


        }


        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if(MainFrame.CanGoBack)
                MainFrame.GoBack();

        }

        private void BtnServices_Click(object sender, RoutedEventArgs e)
        {
        MainFrame.Navigate(new papka.GoodPage());
        }

        private void BtnTimeSheet_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new papka.TimeSheetPage());
        }
    }



        
    
}
