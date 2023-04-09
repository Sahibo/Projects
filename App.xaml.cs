using System.Windows;
using ECommerceAdmin.Services.Classes;
using ECommerceAdmin.Services.Interfaces;
using ECommerceAdmin.View;
using ECommerceAdmin.ViewModel;
using GalaSoft.MvvmLight.Messaging;

namespace ECommerceAdmin
{
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
            Container.RegisterSingleton<AdminViewModel>();
            Container.RegisterSingleton<AddProductViewModel>();
            Container.RegisterSingleton<EditProductViewModel>();
            Container.RegisterSingleton<AttributesViewModel>();

            Container.Verify();
        }

        private void MainStartup()
        {
            Window adminView = new MainWindowView();

            adminView.DataContext = Container?.GetInstance<MainWindowViewModel>();
            adminView.ShowDialog();
        }
    }
}
