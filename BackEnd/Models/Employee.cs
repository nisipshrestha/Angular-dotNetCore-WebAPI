using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApi.CustomerValidation;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Employee : Person
    {
        [AgeVerification(18, ErrorMessage = "Age doesn't meet required criteria! ")]
        public new int Age { get; set; }
    }
}
