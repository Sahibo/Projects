using ECommerce.Message;
using GalaSoft.MvvmLight;

namespace ECommerce.Services.Interfaces
{
    public interface INavigationService
    {
        public void NavigateTo<T>(ParameterMessage? message = null) where T : ViewModelBase;
    }
}
