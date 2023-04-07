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
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using ECommerce.Message;

namespace ECommerce.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IMessenger? _messenger;

        private readonly ECommerceContext _db;
        private readonly DbService _service;
        public ObservableCollection<Category> _categories { get; set; } = new();
        private ObservableCollection<Product> _products;

        public Product product { get; set; } = new();
        private Category _selectedCategory;
        
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                Set(ref _products, value);
            }
        }
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                Set(ref _selectedCategory, value);
                Products = new ObservableCollection<Product>(_db.Products.Where(p => p.CategoryId == _selectedCategory.Id));
            }
        }

        public HomeViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;

            _db = new ECommerceContext();
            _service = new DbService(_db);
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

        
        public RelayCommand<Product> ProductBtn
        {
            get => new(product =>
            {
                    //Take the selected product

                    //if (name != null)
                    //{
                    //    MessageBox.Show(name.Name);
                    //}

                    //product = _db.Products.Where(x => x.Id == id)

                    _navigationService.NavigateTo<ProductViewModel>(product);
            });
        }

    }
}