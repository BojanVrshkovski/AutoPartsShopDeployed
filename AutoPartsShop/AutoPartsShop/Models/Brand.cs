using AutoPartsShop.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Models
{
    public class Brand:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Picture of the brand")]
        [Required(ErrorMessage ="Picture of the brand is required")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        //Relationships
        public List<Brand_PartName> Brands_PartNames { get; set; }
    }
}
