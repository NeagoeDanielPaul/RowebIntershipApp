using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RowebIntershipApp.Data;
using RowebIntershipApp.Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RowebIntershipApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryContext categoryContext;

        public CategoryRepository(CategoryContext categoryContext)
        {
            this.categoryContext = categoryContext;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await categoryContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await categoryContext.Categories.FirstOrDefaultAsync(c => c.categoryId == id);
        }

        public async Task<Category> AddCategory(Category category)
        {
            var result = await categoryContext.Categories.AddAsync(category);
            await categoryContext.SaveChangesAsync();
            
            return result.Entity;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            var result = await categoryContext.Categories.FirstOrDefaultAsync(c => c.categoryId == category.categoryId);

            if(result != null)
            {
                result.Name = category.Name;
                result.Description = category.Description;

                await categoryContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Category> DeleteCategory(int Id)
        {
            var result = await categoryContext.Categories.FirstOrDefaultAsync(c => c.categoryId == Id);
            if(result != null)
            {
                categoryContext.Categories.Remove(result);
                await categoryContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
