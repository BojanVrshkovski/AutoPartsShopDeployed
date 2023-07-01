using AutoPartsShop.Data.Base;
using AutoPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Data.Services
{
    public class ShopsService : EntityBaseRepository<Shop>, IShopsService
    {
       
        public ShopsService(AppDbContext context):base(context)
        {

        }
    }
}
