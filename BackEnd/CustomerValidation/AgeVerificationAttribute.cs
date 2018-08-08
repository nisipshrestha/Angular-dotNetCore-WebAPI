using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.Extensions.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.Reflection;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.CustomerValidation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class AgeVerificationAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int _age;

        public AgeVerificationAttribute(int age)
        {
            _age = age;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Employee employee = (Employee)validationContext.ObjectInstance;
            var errorMessage = FormatErrorMessage(validationContext.DisplayName);
            //employee.Age = value
            return ((int)value >= _age)
                ? ValidationResult.Success
                : new ValidationResult(errorMessage);
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            var errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            MergeAttribute(context.Attributes, "data-val-ageVerification", errorMessage);
        }

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }

            attributes.Add(key, value);
            return true;
        }



    }
}
