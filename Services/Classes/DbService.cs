using ECommerceAdmin.Data.DbContext;
using ECommerceAdmin.Model;
using System.Linq;
using System.Collections.ObjectModel;

namespace ECommerceAdmin.Services.Classes
{
    public class DbService
    {
        private readonly EcommerceContext _context;

        public DbService(EcommerceContext context)
        {
            _context = context;
        }

        public ObservableCollection<Product> SearchProducts(string result)
        {
            return new ObservableCollection<Product>(_context.Products.Where(p => p.Name.Equals(result) || p.Make.Equals(result) || p.CategoryId.ToString().Equals(result)).ToList());

        }

        public ObservableCollection<Category> SearchCategories(string result)
        {
            return new ObservableCollection<Category>(_context.Categories.Where(p => p.Name.Equals(result) || p.Gender.Equals(result)).ToList());

        }
        
        public ObservableCollection<User> SearchAdmins(string result)
        {
            return new ObservableCollection<User>(_context.Users.Where(p => p.Name.Equals(result) || p.Role.Equals(result)).ToList());

        }
    }
}
