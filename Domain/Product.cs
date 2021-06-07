using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowebIntershipApp.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double BasePrice { get; set; }
        public string Image { get; set; }
        public int CtId { get; set; }

        [ForeignKey("CtId")]
        public Category Category { get; set; }
    }
}
