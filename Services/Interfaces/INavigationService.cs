using ECommerce.Message;
using GalaSoft.MvvmLight;

namespace ECommerce.Services.Interfaces
{
    public interface INavigationService
    {
        public void NavigateTo<T>(object? data = null) where T : ViewModelBase;
    }
}
