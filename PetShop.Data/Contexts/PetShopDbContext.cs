using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShop.Models.Entities;

namespace PetShop.Data.Contexts;

public partial class PetShopDbContext : DbContext
{
    public PetShopDbContext()
    {
    }

    public PetShopDbContext(DbContextOptions<PetShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>()
        .Property(a => a.AnimalId)
        .ValueGeneratedOnAdd();

        modelBuilder.Entity<Category>()
            .Property(c => c.CategoryId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Comment>()
            .Property(c => c.CommentId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.Animals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Animals_Categories");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasOne(d => d.Animal).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Animals");
        });

        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



    public void SeedData(PetShopDbContext context)
    {
        if (!context.Categories.Any())
        {
            context.AddRange(new List<Category>
            {
                 new Category { /*CategoryId = -1,*/ Name = "Mammals" },
                 new Category { /*CategoryId = -2,*/ Name = "Aquatic" },
                 new Category { /*CategoryId = -3,*/ Name = "Birds" },
                 new Category { /*CategoryId = -4,*/ Name = "Reptiles" },
                 new Category { /*CategoryId = -5,*/ Name = "Amphibians" }
            });
            context.SaveChanges();
        }

        if (!context.Animals.Any())
        {
            context.AddRange(new List<Animal>
            {
                    new Animal
                    {
                        //AnimalId = -1,
                        Name = "Cat",
                        CategoryId = 1,
                        Age = 1,
                        PhotoUri = "/Images/Cat.jpg",
                        Description = "Cats are graceful, carnivorous (meat-eating) mammals" +
                        " with sharp teeth and claws. Most kinds of cat prey on other mammals " +
                        "or birds, and most hunt alone at night. Only lions live and hunt in groups." +
                        " The claws of cats are extended to help grip their prey, but retracted " +
                        "(pulled back) when not in use"
                    },

                    new Animal
                    {
                        //AnimalId = -2,
                        Name = "Goldfish",
                        CategoryId = 2,
                        Age = 2,
                        PhotoUri = "/Images/Goldfish.jpg",
                        Description = "The common goldfish has two sets of paired fins - the pectoral fins and " +
                        "pelvic fins, and three single fins- the dorsal, caudal, and anal fin. The head lacks scales." +
                        " Goldfish have very large eyes and acute senses of smell and hearing"
                    },

                    new Animal
                    {
                        //AnimalId = -3,
                        Name = "Owl",
                        CategoryId = 3,
                        Age = 3,
                        PhotoUri = "/Images/Owl.jpg",
                        Description = "Owl bird traits include large eyes, feathered bodies, and oviparous (egg-laying)" +
                        " reproduction. Because they are birds of prey, meaning that they are hunters, owls have" +
                        " front-facing eyes, excellent vision, and sharp talons. They also have large heads and hooked beaks"
                    },

                    new Animal
                    {
                        //AnimalId = -4,
                        Name = "Cobra",
                        CategoryId = 4,
                        Age = 2,
                        PhotoUri = "/Images/Cobra.jpg",
                        Description = "Cobras are venomous snakes related to taipans, coral snakes, and mambas, all" +
                        " members of the Elapidae family. Snakes in this family cannot fold their fangs down, as vipers" +
                        " can, so the fangs are generally shorter. They kill their prey by injecting venom through their fangs"
                    },

                    new Animal
                    {
                        //AnimalId = -5,
                        Name = "Frog",
                        CategoryId = 5,
                        Age = 1,
                        PhotoUri = "/Images/Frog.jpg",
                        Description = "A frog has smooth, moist skin and big, bulging eyes. Its hind legs are more" +
                        " than twice as long as its front ones. Most frogs have webbed back feet to help them leap " +
                        "and swim. Tree frogs have sticky disks on the tips of their fingers and toes"
                    }
            });
            context.SaveChanges();
        }

        if (!context.Comments.Any())
        {
            context.AddRange(new List<Comment>
            {
                   new Comment {/* CommentId = -1,*/ Text = "A great Domestic animal", AnimalId = 1 },
                   new Comment {/* CommentId = -2,*/ Text = "Easy upkeep", AnimalId = 1 },
                   new Comment {/* CommentId = -3,*/ Text = "Very calming", AnimalId = 2 },
                   new Comment {/* CommentId = -4,*/ Text = "Has a wingspan of over a meter", AnimalId = 3 },
                   new Comment {/* CommentId = -5,*/ Text = "Very fast reactions", AnimalId = 4 },
                   new Comment {/* CommentId = -6,*/ Text = "Has an impressive hood", AnimalId = 4 },
                   new Comment {/* CommentId = -7,*/ Text = "Can leap quite a distance", AnimalId = 5 }
            });
            context.SaveChanges();
        }

    }
}
