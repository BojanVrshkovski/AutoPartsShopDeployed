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
    public class NewPartNameVM
    {
        public int Id { get; set; }
        [Display(Name= "Part name")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Display(Name = "Part description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Part image")]
        [Required(ErrorMessage = "Image is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Part category is required")]
        public PartCategory PartCategory { get; set; }

        //Relationships
        [Display(Name = "Select brand(s)")]
        [Required(ErrorMessage = "Part brand(s) is required")]
        public List<int> BrandIds { get; set; }

        //Shop
        [Display(Name = "Select a shop")]
        [Required(ErrorMessage = "Shop is required")]
        public int ShopId { get; set; }


        //Producer
        [Display(Name = "Select a manufacturer")]
        [Required(ErrorMessage = "Manufacturer is required")]
        public int ProducerId { get; set; }
       
    }
}
