using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ECommerce.Data.DbContext;
using ECommerce.Message;
using ECommerce.Models;
using ECommerce.Services.Classes;
using ECommerce.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace ECommerce.ViewModel
{
    class ProductViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IMessenger? _messenger;
        private readonly ECommerceContext _db;
        private readonly DbService _service;
        public Product product { get; set; } = new();

        public ProductViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _messenger = messenger;
            _navigationService = navigationService;

            _db = new ECommerceContext();
            _service = new DbService(_db);

            _messenger.Register<DataMessage>(this, message =>
            {
                product = message.Data as Product;
                if (product != null)
                {
                    MessageBox.Show(product.Id.ToString());
                }
            });

        }

        public RelayCommand BackBtn
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<HomeViewModel>();
            });
        }
    }
}
