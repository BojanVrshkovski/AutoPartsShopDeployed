using AutoPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Data.ViewModels
{
    public class NewPartNameDropDownsVM
    {
        public NewPartNameDropDownsVM()
        {
            Producers = new List<Producer>();
            Shops = new List<Shop>();
            Brands = new List<Brand>();
        }

        public List<Producer> Producers { get; set; }
        public List<Shop> Shops { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
