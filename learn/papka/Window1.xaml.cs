﻿using System;
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

namespace learn.papka
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    /// 



    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        public string Password
        {
            get { return Pass.Password; }
        }
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
