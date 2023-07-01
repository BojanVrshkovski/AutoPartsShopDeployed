using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Models
{
    public class Brand_PartName
    {
        public int PartNameId { get; set; }
        public PartName PartName { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
