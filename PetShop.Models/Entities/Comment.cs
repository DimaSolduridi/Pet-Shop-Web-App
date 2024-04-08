using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PetShop.Models.Entities;

public partial class Comment
{
    [Key]
    public int CommentId { get; set; }

    public int AnimalId { get; set; }

    public string Text { get; set; } = null!;

    [ForeignKey("AnimalId")]
    [InverseProperty("Comments")]
    public virtual Animal Animal { get; set; } = null!;
}
