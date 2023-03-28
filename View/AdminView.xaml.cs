using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ECommerceAdmin.View
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : UserControl
    {
        public AdminView()
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