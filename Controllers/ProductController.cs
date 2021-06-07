using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RowebIntershipApp.Repositories;
using RowebIntershipApp.Domain;
using RowebIntershipApp.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using RowebIntershipApp.Models;
using Microsoft.AspNetCore.Hosting;

namespace RowebIntershipApp.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly IProductRepository productRepository;
        protected readonly IWebHostEnvironment webHostEnviroment;


        public ProductController(IProductRepository productRepository, IWebHostEnvironment webHostEnviroment)
        {
            this.productRepository = productRepository;
            this.webHostEnviroment = webHostEnviroment;
        }

        [HttpGet]
        [Route("product")]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return await productRepository.GetProducts();
        }

        [HttpGet]
        [Route("product/{categoryId?}")]
        public async Task<ActionResult<List<Product>>> Get(int categoryId)
        {
            var result = await productRepository.GetProduct(categoryId);
            return result;
        }

        [HttpPost]
        [Route("product")]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            var createdProduct = await productRepository.AddProduct(product);
            return CreatedAtAction(nameof(Get),
                new { ProductId = createdProduct.ProductId }, createdProduct);
        }

        
        [HttpPost]
        [Route("product/photo")]
        public async Task<ActionResult<Product>> UploadPhoto(int id, [FromForm(Name = "body")]IFormFile file)
        {
            var product = await productRepository.GetProductById(id);
            

            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            product.Image = fileName;

            fileName = Path.Combine(webHostEnviroment.WebRootPath, "Images", fileName);

            using (Stream fileStream = new FileStream(fileName, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return await productRepository.UpdateProduct(product);

             

        }

        [HttpPut]
        [Route("product")]
        public async Task<ActionResult<Product>> Put(int id, Product product)
        {
            product.ProductId = id;
            return await productRepository.UpdateProduct(product);
           
        }

        [HttpDelete]
        [Route("product")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            return await productRepository.DeleteProduct(id);
         
        }
    }
}
