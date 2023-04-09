using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ECommerceAdmin.Services.Interfaces;
using ECommerceAdmin.Data.DbContext;
using ECommerceAdmin.Model;
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using System.Windows.Markup;
using System.Threading.Tasks;
using ECommerceAdmin.Services.Classes;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;

namespace ECommerceAdmin.ViewModel
{
    class AdminViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IMessenger? _messenger;

        private readonly EcommerceContext _db;
        private readonly DbService _service;

        private ObservableCollection<Product> _products;
        private ObservableCollection<ProductAttribute> _productAttributes;
        private ObservableCollection<Category> _categories;
        private ObservableCollection<User> _admins;
        private ObservableCollection<Order> _orders;

        
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                Set(ref _products, value);
               
            }
        }
        public ObservableCollection<ProductAttribute> ProductAttributes
        {
            get => _productAttributes;
            set
            {
                Set(ref _productAttributes, value);

            }
        }
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                Set(ref _categories, value);
            }
        }
        public ObservableCollection<User> Admins
        {
            get => _admins;
            set
            {
                Set(ref _admins, value);
            }
        }
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                Set(ref _orders, value);
            }
        }

        public AdminViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;

            _db = new EcommerceContext();
            _service = new DbService(_db);

            Products = new ObservableCollection<Product>(_db.Products.ToList());
            ProductAttributes = new ObservableCollection<ProductAttribute>(_db.ProductAttributes.ToList());
            Categories = new ObservableCollection<Category>(_db.Categories.ToList());
            Admins = new ObservableCollection<User>(_db.Users.Where(a => a.Role != "User").ToList());
            Orders = new ObservableCollection<Order>(_db.Orders.ToList());

        }

        #region Products

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                Set(ref _selectedProduct, value);
            }
        }

        private string _searchProductText;
        public string SearchProductText
        {
            get { return _searchProductText; }
            set
            {
                Set(ref _searchProductText, value);
            }
        }


        public RelayCommand SearchProductBtn => new(async () =>
        {
            //find better method
            if (_searchProductText.IsNullOrEmpty())
                Products = new ObservableCollection<Product>(_db.Products.ToList());
            else
                Products = await Task.Run(() => _service.SearchProducts(_searchProductText));
        });


        public RelayCommand AddProductBtn
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<AddProductViewModel>();
            });
        }

        public RelayCommand DeleteProductBtn
        {
            get => new(() =>
            {
                if (_selectedProduct != null)
                {
                    _db.Products.Remove(_selectedProduct);
                    _db.SaveChangesAsync();

                    Products.Remove(_selectedProduct);
                }
            });
        }

        public RelayCommand EditProductBtn
        {
            get => new(() =>
            {
                //send selected product
                _navigationService.NavigateTo<EditProductViewModel>();
            });
        }
        public RelayCommand ProductAttributesBtn
        {
            get => new(() =>
            {
                //send selected product
                _navigationService.NavigateTo<AttributesViewModel>();
            });
        }
        #endregion

        #region Categories

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                Set(ref _selectedCategory, value);
            }
        }

        private string _searchCategoryText;
        public string SearchCategoryText
        {
            get { return _searchCategoryText; }
            set
            {
                Set(ref _searchCategoryText, value);
            }
        }


        public RelayCommand SearchCategoryBtn => new(async () =>
        {
            //find better method
            if (_searchCategoryText.IsNullOrEmpty())
                Categories = new ObservableCollection<Category>(_db.Categories.ToList());
            else
                Categories = await Task.Run(() => _service.SearchCategories(_searchCategoryText));
        });


        //public RelayCommand AddCategoryBtn
        //{
        //    get => new(() =>
        //    {
        //        _navigationService.NavigateTo<AddCategoryViewModel>(); //selected item goes to the new window
        //    });
        //}

        public RelayCommand DeleteCategoryBtn
        {
            get => new(() =>
            {
                if (_selectedCategory != null)
                {
                    _db.Categories.Remove(_selectedCategory);
                    _db.SaveChangesAsync();

                    Categories.Remove(_selectedCategory);
                }
            });
        }

        #endregion

        #region Admins

        private User _selectedAdmin;
        public User SelectedAdmin
        {
            get { return _selectedAdmin; }
            set
            {
                Set(ref _selectedAdmin, value);
            }
        }

        private string _searchAdminText;
        public string SearchAdminText
        {
            get { return _searchAdminText; }
            set
            {
                Set(ref _searchAdminText, value);
            }
        }


        public RelayCommand SearchAdminBtn => new(async () =>
        {
            //find better method
            if (_searchAdminText.IsNullOrEmpty())
                Admins = new ObservableCollection<User>(_db.Users.ToList());
            else
                Admins = await Task.Run(() => _service.SearchAdmins(_searchAdminText));
        });


        //public RelayCommand AddCategoryBtn
        //{
        //    get => new(() =>
        //    {
        //        _navigationService.NavigateTo<AddCategoryViewModel>();
        //    });
        //}

        public RelayCommand DeleteAdminBtn
        {
            get => new(() =>
            {
                //Add condition
                if (_selectedCategory != null)
                {
                    _db.Users.Remove(_selectedAdmin);
                    _db.SaveChangesAsync();

                    Admins.Remove(_selectedAdmin);
                }
            });
        }

        #endregion
    }
}
