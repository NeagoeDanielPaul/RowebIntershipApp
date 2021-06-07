using RowebIntershipApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RowebIntershipApp.Models
{
    public class CategoryRespresentation
    {
        public CategoryRespresentation(Category category)
        {
            { Id = category.categoryId; Name = category.Name; Description = category.Description; }
        }

        public CategoryRespresentation()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        internal Category GetEntity(int id)
        {
            this.Id = id;
            return new Category
            {
                categoryId = id,
                Name = Name,
                Description = Description
            };
        }

        internal void PutEntity(Category slCategory)
        {
            slCategory.Description = Description;
            slCategory.Name = Name;
        }
    }
}
