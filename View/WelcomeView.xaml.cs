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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ECommerce.View
{
    /// <summary>
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : UserControl
    {
        public WelcomeView()
        {
            InitializeComponent();
        }

        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void MinimizeBtn(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            App.Current.MainWindow.DragMove();
        }
    }
}