using ECommerceAdmin.Message;
using ECommerceAdmin.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace ECommerceAdmin.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ViewModelBase? CurrentViewModel { get; set; }

        private INavigationService? _navigationService;

        private readonly IMessenger? _messenger;

        public MainWindowViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            CurrentViewModel = App.Container?.GetInstance<AdminViewModel>();

            _messenger = messenger;

            _messenger.Register<NavigationMessage?>(this, message =>
            {
                var viewModel = App.Container?.GetInstance(message?.ViewModelType!) as ViewModelBase;
                CurrentViewModel = viewModel;
            });
        }
    }
}
