using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amada_Management.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        [MinLength(2, ErrorMessage = "Denumirea este prea scurta !"),
         MaxLength(200, ErrorMessage = "Denumirea este prea lunga!")]
        public string Denumire { get; set; }
        public int Pret { get; set; }

        [MinLength(10, ErrorMessage = "Prea putine informatii"),
        MaxLength(200, ErrorMessage = "Prea multe informatii")]
        public string Informatii { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        // one to many
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual Type Type { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> TypesList { get; set; }

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

    public class Initp : DropCreateDatabaseIfModelChanges<DbCtx>
    {
        protected override void Seed(DbCtx ctx)
        {
            Type meniu1 = new Type { TypeId = 1, Name = "Vegan" };
            Type meniu2 = new Type { TypeId = 2, Name = "Carnivor" };

            ctx.Types.Add(meniu1);
            ctx.Types.Add(meniu2);

            ctx.Foods.Add(new Food
            {
                FoodId = 1,
                Denumire = "Pastrav",
                Pret = 35,
                Informatii = " Un pastrav proaspat",
                TypeId=meniu2.TypeId,
                Categories = new List<Category> {
                    new Category { Name = "Peste"}
                }

            }); ;
            ctx.Foods.Add(new Food
            {
                FoodId = 2,
                Denumire = "Salata de rosii",
                Pret = 10,
                Informatii = " O salata fresh",
                TypeId = meniu1.TypeId,
                Categories = new List<Category> {
                    new Category { Name = "Salate"}
                }
            });
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}