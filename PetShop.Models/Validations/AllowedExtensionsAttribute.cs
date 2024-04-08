using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models.Validations
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }
        
        public override bool IsValid(object? value)
        {
            var file = value as IFormFile;
            
            if (file != null)
            {
                var extension = Path.GetExtension(file!.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }

      
    }
}
