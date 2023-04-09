using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAdmin.Data.DbContext;
using ECommerceAdmin.Model;
using ECommerceAdmin.Services.Classes;
using ECommerceAdmin.Services.Interfaces;
using GalaSoft.MvvmLight;

namespace ECommerceAdmin.ViewModel
{
    class EditProductViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private readonly EcommerceContext _db;
        private readonly DbService _service;
        public ObservableCollection<Product> _products { get; set; }
        public ObservableCollection<Category> _categories { get; set; }

        public EditProductViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _db = new EcommerceContext();
            _service = new DbService(_db);

            _products = new ObservableCollection<Product>(_db.Products.ToList());
            _categories = new ObservableCollection<Category>(_db.Categories.ToList());
        }


    }
}
