using GalaSoft.MvvmLight;
using System.Linq;
using ECommerceAdmin.Data.DbContext;
using ECommerceAdmin.Services.Classes;
using ECommerceAdmin.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using ECommerceAdmin.Model;
using System.Collections.Generic;

namespace ECommerceAdmin.ViewModel
{
    class AddProductViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private readonly EcommerceContext _db;
        private readonly DbService _service;

        public ObservableCollection<Product> _products { get; set; }
        public ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                Set(ref _categories, value);
            }
        }
        public Product _product { get; set; } = new();
        public string Url { get; } = "https://www.farfetch.com/az/shopping/men/items.aspx";
        public AddProductViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _db = new EcommerceContext();
            _service = new DbService(_db);

            _products = new ObservableCollection<Product>(_db.Products.ToList());
            _categories = new ObservableCollection<Category>(_db.Categories.ToList());
        }

        public ICommand OpenUrlCommand => new RelayCommand(() =>
        {
            Process.Start(new ProcessStartInfo(Url) { UseShellExecute = true });
        });

        public List<string> CategoriesWithGender
        {
            get
            {
                return Categories.Select(c => $"{c.Name} {c.Gender}").ToList();
            }
        }
    }
}
