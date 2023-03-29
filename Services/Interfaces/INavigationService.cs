using ECommerceAdmin.Message;
using GalaSoft.MvvmLight;

namespace ECommerceAdmin.Services.Interfaces
{
    public interface INavigationService
    {
        public void NavigateTo<T>(object? data = null) where T : ViewModelBase;
    }
}
