using FruitsShop.Data;
using FruitsShop.Dto;
using FruitsShop.Dtos;
using FruitsShop.Helpers;
using FruitsShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        


    }
}
