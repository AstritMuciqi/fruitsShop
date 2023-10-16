using FruitsShop.Data;
using FruitsShop.Dto;
using FruitsShop.Dtos;
using FruitsShop.Helpers;
using FruitsShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace FruitsShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private readonly AppDbContext _context;

        public ProductController( AppDbContext context)
        {
            _context = context;
        }


        // GET: api/<ArticleController>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(Product product)
        {

            // Create a new Comment object and populate it with data
            var newProduct = new Product
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Date = product.Date,
                Category = product.Category,
            };

            await _context.Products.AddAsync(newProduct);

            await _context.SaveChangesAsync();


            return Ok(new { message = "Product added successfully!", newProduct });

            //return BadRequest(new ProblemDetails { Title = "Problem with creating new comments!" });

        }

        [HttpPost]
        [Route("EditProduct")]
        public async Task<IActionResult> EditProduct(Product product)
        {

            // Create a new Comment object and populate it with data

            Product existingProduct = await _context.Products.FindAsync(product.Id);

            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.Date = product.Date;
            existingProduct.Category = product.Category;

            _context.Products.Update(existingProduct);

            await _context.SaveChangesAsync();


            return Ok(new { message = "Product edited successfully!", existingProduct });

            //return BadRequest(new ProblemDetails { Title = "Problem with creating new comments!" });

        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return Ok();

            }
            else
            {
                return BadRequest();
            }


        }

    }
}
