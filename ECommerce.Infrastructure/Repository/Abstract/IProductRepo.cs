using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repository.Abstract
{
    public interface IProductRepo
    {
        Task AddNewProductAsync(Product newProduct);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task UpdateProductAsync(Product product);
        Task<List<Product>> GetProductsByCategoryAsync(int categoryId);

    }
}
