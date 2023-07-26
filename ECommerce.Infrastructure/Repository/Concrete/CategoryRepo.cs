using ECommerce.Data;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repository.Concrete
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddNewCategoryAsync(Category category)
        {
            try 
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                throw new Exception("Kategori ekleme sırasında bir hata oluştu!");
            }
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            try {
                var result = await _context.Categories.ToListAsync();
                return result;
            }catch (Exception ex)
            {
                throw new Exception("Kategoriler listelenirken bir hata meydana geldi!");
            }
        }
    }
}
