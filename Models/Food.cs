using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Amada_Management.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        [MaxLength(256)]
        public string Denumire { get; set; }
        public int Pret { get; set; }

        [MinLength(10, ErrorMessage = "Informations cannot be less than 10"),
 MaxLength(200, ErrorMessage = "Informations cannot be more than 200")]
        public string Informatii { get; set; }

        // one to many
        [Column("Category_id")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Type> Types { get; set; }

    }

    public class DbCtx : DbContext
    {
        public DbCtx() : base("DbConnectionString")
        {
            Database.SetInitializer<DbCtx>(new Initp());
            //Database.SetInitializer<DbCtx>(new CreateDatabaseIfNotExists<DbCtx>());
            //Database.SetInitializer<DbCtx>(new DropCreateDatabaseIfModelChanges<DbCtx>());
            //Database.SetInitializer<DbCtx>(new DropCreateDatabaseAlways<DbCtx>());
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

    public class Initp : DropCreateDatabaseAlways<DbCtx>
    {
        protected override void Seed(DbCtx ctx)
        {
            ctx.Foods.Add(new Food
            {
                FoodId = 1,
                Denumire = "Pastrav",
                Pret = 35,
                Informatii = " Un pastrav proaspat",
                Category = new Category { Name = "Peste" },
                Types = new List<Type> {
                    new Type { Name = "Carnivor"}
                }

            }); ;
            ctx.Foods.Add(new Food
            {
                FoodId = 2,
                Denumire = "Salata de rosii",
                Pret = 10,
                Informatii = " O salata fresh",
                Category = new Category { Name = "Salate" },
                Types = new List<Type> {
                    new Type { Name = "Vegan"}
                }
            });
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}