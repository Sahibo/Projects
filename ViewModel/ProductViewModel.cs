using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data.DbContext;
using ECommerce.Message;
using ECommerce.Models;
using ECommerce.Services.Classes;
using ECommerce.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace ECommerce.ViewModel
{
    class ProductViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IMessenger? _messenger;
        private readonly ECommerceContext _db;
        private readonly DbService _service;
        public Product _product { get; set; } = new();

        public ProductViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;

            _db = new ECommerceContext();
            _service = new DbService(_db);
            _messenger.Register<ParameterMessage>(this, param =>
            {
                _product = param?.Message as Product;
            });
        }


        
    }
}
