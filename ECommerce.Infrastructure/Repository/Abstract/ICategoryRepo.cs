using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repository.Abstract
{
    public interface ICategoryRepo
    {
        Task AddNewCategoryAsync(Category category);
        Task<List<Category>> GetAllCategoriesAsync();
    }
}
