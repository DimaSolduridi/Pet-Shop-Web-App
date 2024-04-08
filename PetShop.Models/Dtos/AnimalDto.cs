using PetShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PetShop.Models.Validations;

namespace PetShop.Models.Dtos
{
    public class AnimalDto
    {
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "Name is a required field")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please enter a valid name.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Age is a required field")]
        [Range(0, 150)]
        public int Age { get; set; }

        [StringLength(500,ErrorMessage ="Please enter no more then 500 characters")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        public string? PhotoUri { get; set; }

        [Required(ErrorMessage = "Category field is required")]
        public int CategoryId { get; set; }

        
        public virtual CategoryDto? Category { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        [NotMapped]
        [Display(Name = "Choose animal photo")]
        [AllowedExtensions([".jpg", ".jpeg", ".png"], ErrorMessage = "Your image's filetype is not valid.")]
        public IFormFile? AnimalPhoto { get; set; }
    }
}
