using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RowebIntershipApp.Domain;

namespace RowebIntershipApp.Models
{
    public class ProductRepresentation
    {
        public ProductRepresentation(Product product)
        {
            { ProductId = product.ProductId; Name = product.Name; Description = product.Description; Price = product.Price; BasePrice = product.BasePrice; Image = product.Image; }
        }

        public ProductRepresentation()
        {

        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double BasePrice { get; set; }
        public string Image { get; set; }
    }
}
