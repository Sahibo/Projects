using System;
using ECommerce.Data.DbContext;
using ECommerce.Services.Classes;
using ECommerce.Services.Interfaces;
using GalaSoft.MvvmLight;
using ECommerce.Models;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using ECommerce.Message;

namespace ECommerce.ViewModel
{
    public class HomeViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        private IMessenger? _messenger;
        private readonly ECommerceContext _db;
        private readonly DbService _service;
        public ObservableCollection<Category> _categories { get; set; } = new();
        private ObservableCollection<Product> _products;

        public Product product { get; set; } = new();

        public event PropertyChangedEventHandler PropertyChanged;
       
        public HomeViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;

            _db = new ECommerceContext();
            _service = new DbService(_db);

            //_products = new ObservableCollection<Product>();

            //_messenger.Register<ParameterMessage>(this, param =>
            //{
            //    _selectedProduct = param?.Message as Product;
            //});

        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand MenBtn => new(async () =>
        {
            _categories.Clear();
            _categories = await Task.Run(() => _service.MenuCategories("Men"));
        });

        public RelayCommand WomenBtn => new(async () =>
        {
            _categories.Clear();
            _categories = await Task.Run(() => _service.MenuCategories("Women"));
        });

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged(nameof(SelectedCategory));

                    // Filter products based on the selected category
                    Products = new ObservableCollection<Product>(_db.Products.Where(p => p.CategoryId == _selectedCategory.Id));
                }
            }
        }

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                if (_products != value)
                {
                    _products = value;
                    OnPropertyChanged(nameof(Products));
                }
            }
        }

        public RelayCommand<Product> ProductBtn
        {
            get => new(product =>
            {
                    _navigationService.NavigateTo<ProductViewModel>(product);
            });
        }


    }
}