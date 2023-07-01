using AutoPartsShop.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Picture of the manufacturer")]
        [Required(ErrorMessage = "The Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "The Full Name is required")]
        public string FullName { get; set; }

        [Display(Name ="Biography for the manufacturer")]
        [Required(ErrorMessage = "The Biography is required")]
        public string Bio { get; set; }

        //Relationships
        public List<PartName> PartNames { get; set; } 
    }
}
