using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ECommerceAdmin.Services.Interfaces;
using ECommerceAdmin.Data.DbContext;
using ECommerceAdmin.Model;
using System.ComponentModel;

namespace ECommerceAdmin.ViewModel
{
    class AdminViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        private IMessenger? _messenger;

        private readonly EcommerceContext _db;
        

        private ObservableCollection<Product> _products;
        private ObservableCollection<Category> _categories;
        private ObservableCollection<User> _admins;
        private ObservableCollection<Order> _orders;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public AdminViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;

            _db = new EcommerceContext();

            Products = new ObservableCollection<Product>(_db.Products.ToList());
            Categories = new ObservableCollection<Category>(_db.Categories.ToList());
            Admins = new ObservableCollection<User>(_db.Users.ToList());
            Orders = new ObservableCollection<Order>(_db.Orders.ToList());



        }

        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                if (_products != value)
                {
                    _products = value;
                    OnPropertyChanged(nameof(Products));
                }
            }
        }
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                if (_categories != value)
                {
                    _categories = value;
                    OnPropertyChanged(nameof(Categories));
                }
            }
        }
        public ObservableCollection<User> Admins
        {
            get => _admins;
            set
            {
                if (_admins != value)
                {
                    _admins = value;
                    OnPropertyChanged(nameof(Admins));
                }
            }
        }
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                if (_orders != value)
                {
                    _orders = value;
                    OnPropertyChanged(nameof(Orders));
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
