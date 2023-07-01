using AutoPartsShop.Data.Base;
using AutoPartsShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Data.Services
{
    public class BrandsService : EntityBaseRepository<Brand>, IBrandsService
    {
        private readonly AppDbContext _context;
        public BrandsService(AppDbContext context) : base(context) { }
        
        
    }
}
