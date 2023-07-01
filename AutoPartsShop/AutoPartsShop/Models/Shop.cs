using AutoPartsShop.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Models
{
    public class Shop:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Shop logo")]
        [Required(ErrorMessage = "Shop logo is required")]
        public string Logo { get; set; }
        [Display(Name = "Shop name")]
        [Required(ErrorMessage = "Shop name is required")]
        public string Name { get; set; }
        [Display(Name = "Shop location")]
        [Required(ErrorMessage = "Shop location is required")]
        public string Description { get; set; }


        //Relationships
        public List<PartName> PartNames { get; set; }
    }
}
