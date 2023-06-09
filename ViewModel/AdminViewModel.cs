﻿using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ECommerce.Services.Interfaces;
using ECommerce.Data.DbContext;
using ECommerce.Models;
using ECommerce.Services.Classes;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ViewModel
{
    class AdminViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        private IMessenger? _messenger;

        private readonly ECommerceContext _db;
        private readonly DbService _service;

        private ObservableCollection<Product> _products;
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
        private ObservableCollection<ProductAttribute> _productAttributes;
        public ObservableCollection<ProductAttribute> ProductAttributes
        {
            get => _productAttributes;
            set
            {
                if (_productAttributes != value)
                {
                    _productAttributes = value;
                    OnPropertyChanged(nameof(ProductAttributes));
                }
            }
        }
        public AdminViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;

            _db = new ECommerceContext();
            _service = new DbService(_db);

            //var query = _db.Products
            //    .Join(_db.ProductAttributes,
            //        pa => pa.Id,
            //        p => p.ProductId,
            //        (pa, p) => new { Product = pa, ProductAttribute = p });

            var query = _db.ProductAttributes.Include(x => x.Product);


            Products = new ObservableCollection<Product>(query.Select(x => x.Product).ToList());
            ProductAttributes = new ObservableCollection<ProductAttribute>(query.ToList());
            //Query = new ObservableCollection<object>(query);

        }
        //private ObservableCollection<object> _query;
        //public ObservableCollection<object> Query
        //{
        //    get => _query;
        //    set
        //    {
        //        if (_query != value)
        //        {
        //            _query = value;
        //            OnPropertyChanged(nameof(Query));
        //        }
        //    }
        //}
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
