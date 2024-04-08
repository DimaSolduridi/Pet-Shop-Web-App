using PetShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models.Dtos
{
    public class CommentDto
    {
        public int CommentId { get; set; }

        public int AnimalId { get; set; }

        [Display(Name ="Comment")]
        public string Text { get; set; } = null!;

        //public virtual Animal Animal { get; set; } = null!;
    }
}
