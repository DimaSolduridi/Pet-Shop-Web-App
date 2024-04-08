using Microsoft.AspNetCore.Http;
using PetShop.Models.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PetShop.Models.Entities;

public partial class Animal
{
    [Key]
    public int AnimalId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;
   
    public int Age { get; set; }
    [StringLength(500)]
    public string? Description { get; set; }

    public string? PhotoUri { get; set; }

    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Animals")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Animal")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();


    //public static Animal ToEntity(AnimalDto dto)
    //{
    //    var animal = new Animal();
    //    animal.Name = dto.Name;
    //    animal.Age = dto.Age;

    //}
}
