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
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddNewProductAsync(Product newProduct)
        {
            try 
            {
                _context.Products.Add(newProduct);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                throw new Exception("Ürün ekleme sırasında bir hata oluştu!");
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                var result = await _context.Products.ToListAsync();
                return result;
            }
            catch (Exception ex) {
                throw new Exception("Ürünleri listelerken bir hata meydana geldi!");
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try 
            {
                var result = _context.Products.FirstOrDefault(x => x.Id == id);
                if (result == null) 
                {
                    throw new Exception("Bu id değerinde sahip bir ürün bulunmamaktadır!");
                }
                return result;
            }catch(Exception ex) 
            {
                throw new Exception("Ürün getirilirken bir hata meydana geldi");
            }
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            try {
                var result = await _context.ProductCategoriesMap
                    .Include(x => x.Product)
                    .Where(x => x.CategoryId == categoryId)
                    .Select(x => x.Product)
                    .ToListAsync();
                
                return result;

            }catch (Exception ex)
            {
                throw new Exception("Ürünler listelenirken bir hata meydana geldi!");
            }
        }


        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                throw new Exception("Güncelleme sırasında bir hata meydana geldi!");
            }
        }
    }
}
