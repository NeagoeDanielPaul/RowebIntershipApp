using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RowebIntershipApp.Domain;

namespace RowebIntershipApp.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<Category> DeleteCategory(int Id);
    }
}
