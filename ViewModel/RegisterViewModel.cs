using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ECommerce.Data.DbContext;
using ECommerce.Models;
using ECommerce.Services.Classes;
using GalaSoft.MvvmLight;
using ECommerce.Services.Interfaces;
using GalaSoft.MvvmLight.Command;

namespace ECommerce.ViewModel
{
    internal class RegisterViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private readonly ECommerceContext _db;
        private readonly DbService _service;

        public RegisterViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _db = new ECommerceContext();

            _service = new DbService(_db);

            _users = new ObservableCollection<User>(_db.Users.ToList());
        }

        public ObservableCollection<User> _users { get; set; }
        public User _user { get; set; }
        public string UserName { get; set; }
        public string UserSurname {get; set;}
        public string UserEmail { get; set; }

        public RelayCommand<object> RegisterBtn
        {
            get => new(param =>
            {
                if (param != null)
                {

                    object[] res = (object[])param;
                    var password = (PasswordBox)res[0];
                    var confirm = (PasswordBox)res[1];


                    var checker = new PasswordService(password, confirm);
                    if (checker.IsMatch() && _db.Users.All(u => u.Email != UserEmail))
                    {

                        var user = new User
                        {
                            Name = UserName,
                            Surname = UserSurname,
                            Email = UserEmail,
                            Password = password.Password

                        };

                        _users.Add(user);
                        _db.Users.Add(user);
                        _db.SaveChanges();
                        _navigationService?.NavigateTo<HomeViewModel>();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }

            });
        }

        public RelayCommand LoginBtn
        {
            get => new(() =>
            {
                _navigationService?.NavigateTo<WelcomeViewModel>();
            });
        }


    }
}
