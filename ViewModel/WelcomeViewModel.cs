using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ECommerce.Data.DbContext;
using ECommerce.Models;
using ECommerce.Services.Classes;
using ECommerce.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ECommerce.ViewModel
{
    public class WelcomeViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private readonly ECommerceContext _db;
        private readonly DbService _service;

        public WelcomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _db = new ECommerceContext();
            _service = new DbService(_db);

            _users = new ObservableCollection<User>(_db.Users.ToList());
        }
        public ObservableCollection<User> _users { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public RelayCommand<object> LoginBtn
        //{
        //    get => new RelayCommand<object>(param =>
        //    {
        //        if (param != null)
        //        {
        //            var passwordBox = (PasswordBox)param;
        //            Password = passwordBox.Password;
        //        }

        //        var user = _users.SingleOrDefault(u => u.Email == Email);

        //        if (user != null && Password == user.Password)
        //        {
        //            _navigationService?.NavigateTo<HomeViewModel>();
        //        }
        //        else if (user != null)
        //        {
        //            MessageBox.Show("Invalid password");
        //        }
        //        else
        //        {
        //            MessageBox.Show("User not found");
        //        }
        //    });
        //}
        public RelayCommand RegisterBtn
        {
            get => new(() =>
            {
                _navigationService?.NavigateTo<RegisterViewModel>();
            });
        }

        //udali
        public RelayCommand LoginBtn
        {
            get => new(() =>
            {
                _navigationService?.NavigateTo<HomeViewModel>();
            });
        }


    }
}
