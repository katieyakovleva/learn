using Microsoft.Win32;
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
    /// Логика взаимодействия для GoodAddPage.xaml
    /// </summary>
    public partial class GoodAddPage : Page
    {
        private uslugi _currentGood = new uslugi();

        private string _filePath = null;

        private string _photoName = null;

        private static string _currentDirectory = Directory.GetCurrentDirectory() + @"\photo\";

        public GoodAddPage(uslugi selectedGood)
        {
            InitializeComponent();
            List<uslugi> uslugis = uslugiEntities1.GetContext().uslugis.OrderBy(p => p.Наименование_услуги).ToList();
            if (selectedGood != null)
            {
                _currentGood = selectedGood;
                List<uslugi> uslugis1 = new List<uslugi>();
                _filePath = _currentDirectory + _currentGood.Главное_изображение;
            }
            DataContext = _currentGood;
            _filePath = _currentGood + _currentGood.Главное_изображение;
        }


        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void LoagPhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                if (op.ShowDialog() == true)
                {
                    FileInfo fileInfo = new FileInfo(op.FileName);
                    if (fileInfo.Length > (1024 * 1024 * 2))
                    {
                        throw new Exception("размер файла должен быть меньше 2мб");
                    }
                    ImagePhoto.Source = new BitmapImage(new Uri(op.FileName));
                    _photoName = op.SafeFileName;
                    _filePath = op.FileName;
                    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _filePath = null;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFileds();
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;

            }

            if (_currentGood.код_услуги == 0)
            {
                string photo = ChangePhotoName();
                string dest = _currentDirectory + photo;
                File.Copy(_filePath, dest);
                _currentGood.Главное_изображение = photo;
                uslugiEntities1.GetContext().uslugis.Add(_currentGood);
            }

            try
            {
                if (_filePath != null)
                {
                    string photo = ChangePhotoName();
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentGood.Главное_изображение = photo;
                }

                uslugiEntities1.GetContext().SaveChanges();
                MessageBox.Show("Запись сохранена");
                NavigationService.Navigate(new GoodPage());
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        string ChangePhotoName()
        {
            string x = _currentDirectory + _photoName;
            string photoname = _photoName;
            int i = 0;
            if (File.Exists(x))
            {
                while (File.Exists(x))
                {
                    i++;
                    x = _currentDirectory + i.ToString() + photoname;
                }
                photoname = i.ToString() + photoname;
            }
            return photoname;
        }

        private StringBuilder CheckFileds()
        {
            StringBuilder s = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentGood.Наименование_услуги))
                s.AppendLine("поле названия пустое");
            if (_currentGood.Стоимость < 0)
                s.AppendLine("цена не может быть отрицательной");
            if (_currentGood.Действующая_скидка < 0)
            s.AppendLine("скидка не может быть отрицательной");
            if (_currentGood.Длительность < 0)
                s.AppendLine("длительность не может быть отрицательной");
           
            return s;
        }


    }
}
