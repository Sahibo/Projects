using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ECommerce.ViewModel;
using ECommerce.Data.DbContext;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using GalaSoft.MvvmLight.Command;

namespace ECommerce.Services.Classes
{
    public class DbService
    {
        private readonly ECommerceContext _context;

        public DbService(ECommerceContext context)
        {
            _context = context;
        }

        public ObservableCollection<Category> MenuCategories(string menu)
        {
            return new ObservableCollection<Category>(_context.Categories.Where(g => g.Gender.Equals(menu)).ToList());

        }

        //public async Task<List<Category>> GetCategoriesAsync()
        //{
        //    return await _context.Categories.ToListAsync();
        //}

        //public async Task<ObservableCollection<Category>> MenuCategoriesAsync(string menu)
        //{
        //    var categories = await _context.Categories.Where(g => g.Gender.Equals(menu)).ToListAsync();
        //    return new ObservableCollection<Category>(categories);
        //}

    }
}
