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
using Microsoft.EntityFrameworkCore;

namespace ECommerceAdmin.ViewModel
{
    class EditProductViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private readonly EcommerceContext _db;
        private readonly DbService _service;
        //public ObservableCollection<Product> _products { get; set; }
        //public ObservableCollection<Category> _categories { get; set; }

        public Product product { get; set; }

        public EditProductViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _db = new EcommerceContext();
            _service = new DbService(_db);

            product = _db.Products.SingleOrDefault(x => x.Id == 1);
            //_products = new ObservableCollection<Product>(_db.Products.ToList());
            //_categories = new ObservableCollection<Category>(_db.Categories.ToList());
        }


    }
}
