using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RowebIntershipApp.Domain;
using RowebIntershipApp.Models;

namespace RowebIntershipApp.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetProduct(int categoryId);
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int Id);
    }
}
