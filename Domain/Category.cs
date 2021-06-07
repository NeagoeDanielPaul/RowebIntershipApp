using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RowebIntershipApp.Domain
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        public int categoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
