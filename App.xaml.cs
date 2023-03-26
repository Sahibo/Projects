using System.Windows;
using ECommerce.Services.Classes;
using ECommerce.Services.Interfaces;
using ECommerce.View;
using ECommerce.ViewModel;
using GalaSoft.MvvmLight.Messaging;


namespace ECommerce
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SimpleInjector.Container? Container { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            MainStartup();
            base.OnStartup(e);
        }

        private void Register()
        {
            Container = new();

            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();

            Container.RegisterSingleton<MainWindowViewModel>();
            Container.RegisterSingleton<WelcomeViewModel>();
            Container.RegisterSingleton<RegisterViewModel>();
            Container.RegisterSingleton<HomeViewModel>();
            Container.RegisterSingleton<ProductViewModel>();

            Container.Verify();
        }

        private void MainStartup()
        {
            Window welcomeView = new MainWindowView();

            welcomeView.DataContext = Container?.GetInstance<MainWindowViewModel>();
            welcomeView.ShowDialog();
        }
    }
}