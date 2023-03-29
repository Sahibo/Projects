using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using ECommerceAdmin.Message;
using ECommerceAdmin.Messages;
using ECommerceAdmin.Services.Interfaces;
using ECommerceAdmin.Services.Classes;

namespace ECommerceAdmin.Services.Classes
{
    public class NavigationService : INavigationService
    {
        private readonly IMessenger _messenger;
        public NavigationService(IMessenger messenger)
        {
            _messenger = messenger;
        }
        public void SendData<T>(T? data) where T : class
        {
            if (data != null)
            {
                _messenger.Send(new DataMessage()
                {
                    Data = data
                });
            }
        }

        public void NavigateTo<T>(object? data = null) where T : ViewModelBase
        {
            _messenger.Send(new NavigationMessage()
            {
                ViewModelType = typeof(T)
            });

            if (data != null)
            {
                _messenger.Send(new DataMessage()
                {
                    Data = data
                });
            }
        }
    }
}
