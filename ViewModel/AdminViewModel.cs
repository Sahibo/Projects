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

namespace ECommerceAdmin.ViewModel
{
    class AdminViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IMessenger? _messenger;

        private readonly EcommerceContext _db;
        private readonly DbService _service;

        private ObservableCollection<Product> _products;
        private ObservableCollection<Category> _categories;
        private ObservableCollection<User> _admins;
        private ObservableCollection<Order> _orders;

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                if (_products != value)
                {
                    _products = value;
                    //OnPropertyChanged(nameof(Products));
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
                    //OnPropertyChanged(nameof(Categories));
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
                    //OnPropertyChanged(nameof(Admins));
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
                    //OnPropertyChanged(nameof(Orders));
                }
            }
        }

        public AdminViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;

            _db = new EcommerceContext();
            _service = new DbService(_db);

            Products = new ObservableCollection<Product>(_db.Products.ToList());
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
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    //OnPropertyChanged(nameof(SelectedProduct));
                }
            }
        }

        private string _searchProductText;
        public string SearchProductText
        {
            get { return _searchProductText; }
            set
            {
                if (_searchProductText != value)
                {
                    _searchProductText = value;
                    //OnPropertyChanged(nameof(SearchProductText));
                }
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
                _navigationService.NavigateTo<AddProductViewModel>(); //selected item goes to the new window
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

                }
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
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    //OnPropertyChanged(nameof(SelectedCategory));
                }
            }
        }

        private string _searchCategoryText;
        public string SearchCategoryText
        {
            get { return _searchCategoryText; }
            set
            {
                if (_searchCategoryText != value)
                {
                    _searchCategoryText = value;
                    //OnPropertyChanged(nameof(SearchCategoryText));
                }
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
                if (_selectedAdmin != value)
                {
                    _selectedAdmin = value;
                    //OnPropertyChanged(nameof(SelectedAdmin));
                }
            }
        }

        private string _searchAdminText;
        public string SearchAdminText
        {
            get { return _searchAdminText; }
            set
            {
                if (_searchAdminText != value)
                {
                    _searchAdminText = value;
                    //OnPropertyChanged(nameof(SearchAdminText));
                }
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

                }
            });
        }

        #endregion
    }
}
