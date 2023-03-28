using ECommerceAdmin.Message;
using GalaSoft.MvvmLight;

namespace ECommerceAdmin.Services.Interfaces
{
    public interface INavigationService
    {
        public void NavigateTo<T>(ParameterMessage? message = null) where T : ViewModelBase;
    }
}
