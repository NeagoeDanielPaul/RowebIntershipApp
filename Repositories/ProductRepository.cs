using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RowebIntershipApp.Data;
using RowebIntershipApp.Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RowebIntershipApp.Models;

namespace RowebIntershipApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CategoryContext categoryContext;

        public ProductRepository(CategoryContext categoryContext)
        {
            this.categoryContext = categoryContext;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await categoryContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProduct(int categoryId)
        {
            return await categoryContext.Products.Where(c => c.CtId == categoryId).ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await categoryContext.Products.FirstOrDefaultAsync(c => c.ProductId == id);
        }

        public async Task<Product> AddProduct(Product product)
        {
            var result = await categoryContext.Products.AddAsync(product);
            await categoryContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await categoryContext.Products.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);

            if (result != null)
            {
                result.Name = product.Name;
                result.Description = product.Description;
                result.Price = product.Price;
                result.BasePrice = product.BasePrice;
                result.Image = product.Image;

                await categoryContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Product> DeleteProduct(int Id)
        {
            var result = await categoryContext.Products.FirstOrDefaultAsync(p => p.ProductId == Id);
            if (result != null)
            {
                categoryContext.Products.Remove(result);
                await categoryContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
