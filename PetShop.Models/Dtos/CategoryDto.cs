﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models.Dtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        
        public string Name { get; set; }
    }
}
