using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"[\D][a-zA-Z0-9]+", ErrorMessage = "Only Alphabet or Alphanumeric word")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"[\D][a-zA-Z0-9]+", ErrorMessage = "Only Alphabet or Alphanumeric word")]
        public string LastName { get; set; }

        public bool Status { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
