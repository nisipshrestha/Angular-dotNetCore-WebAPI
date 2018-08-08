using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }

        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
