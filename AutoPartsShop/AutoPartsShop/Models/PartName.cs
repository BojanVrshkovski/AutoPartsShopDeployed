using AutoPartsShop.Data;
using AutoPartsShop.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Models
{
    public class PartName:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public PartCategory PartCategory { get; set; }

        //Relationships
        public List<Brand_PartName> Brands_PartNames { get; set; }

        //Shop
        public int ShopId { get; set; }
        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
