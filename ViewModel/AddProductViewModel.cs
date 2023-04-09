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
using System.IO;
using System.Windows;


namespace ECommerceAdmin.ViewModel
{
    class AddProductViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private readonly EcommerceContext _db;
        private readonly DbService _service;

        public ObservableCollection<Product> _products { get; set; }
        public ObservableCollection<Category> _categories { get; set; }

        public Product _product { get; set; } = new();
        public string Url { get; } = "https://www.farfetch.com/az/shopping/men/items.aspx";
        public string Errors { get; set; }

        public List<int> CategoriesId
        {
            get
            {
                return _categories.Select(c => c.Id).ToList();
            }
        }

        //Test it
        //public List<string> CategoriesWithGender
        //{
        //    get
        //    {
        //        return _categories.Select(c => $"{c.Id}: {c.Name} {c.Gender}").ToList();
        //    }
        //}
        //public string SelectedCategory
        //{
        //    get => SelectedCategory;
        //    set
        //    {
        //        SelectedCategory = value;

        //        var idString = CategoriesWithGender.Where(x => x.Equals(SelectedCategory));
        //        var id = int.Parse(idString.ToString().Substring(0, idString.ToString().IndexOf(':')));

        //        _product.CategoryId = id;
        //    }
        //}
        public AddProductViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _db = new EcommerceContext();
            _service = new DbService(_db);

            _products = new ObservableCollection<Product>(_db.Products.ToList());
            _categories = new ObservableCollection<Category>(_db.Categories.ToList());
        }

        public RelayCommand AddBtn
        {
            get => new(() =>
            {
                //This func doesn't work correctly
                if (_service.ProductService(_product))
                {
                    _products.Add(_product);
                    MessageBox.Show("Product was added!");
                }
                else
                {
                    Errors = "Error!";
                }
            });
        }

        public RelayCommand BackBtn
        {
            get => new(() =>
            {
                _navigationService?.NavigateTo<AdminViewModel>();
            });
        }

        public ICommand OpenUrlCommand => new RelayCommand(() =>
        {
            Process.Start(new ProcessStartInfo(Url) { UseShellExecute = true });
        });

    }
}
