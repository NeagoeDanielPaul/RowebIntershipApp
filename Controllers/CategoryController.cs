using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RowebIntershipApp.Domain;
using RowebIntershipApp.Models;
using RowebIntershipApp.Repositories;

namespace RowebIntershipApp.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public static List<Category> Categories { get; set; }


        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("category")]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return await categoryRepository.GetCategories();
        }

        [HttpGet]
        [Route("category/{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var result =  await categoryRepository.GetCategory(id);
            return result;
        }
        
        
        [HttpPost]
        [Route("category")]
        public async Task<ActionResult<Category>> Post(Category category)
        {
            
            var createdCategory = await categoryRepository.AddCategory(category);
            return CreatedAtAction(nameof(Get),
                new { categoryId = createdCategory.categoryId }, createdCategory);

        }
        
        [HttpPut]
        [Route("category")]
        public async Task<ActionResult<Category>> Put(int id, Category category)
        {
            category.categoryId = id;
            return await categoryRepository.UpdateCategory(category);
        }
        
        [HttpDelete]
        [Route("category")]
        public async Task<ActionResult<Category>> Delete(int id)
        {
            return await categoryRepository.DeleteCategory(id);

        }


    }
    }
