using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitsShop.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }

        public float Price { get; set; }

        public string Category { get; set; }

        public string Date { get; set; }

    }
}
