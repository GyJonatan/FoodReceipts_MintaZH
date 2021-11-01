using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    class FoodReceiptsContext : DbContext
    {
        public DbSet<Ingredients> Ingredients { get;  set; }
        public DbSet<Receipts> Receipts { get; set; }

        public FoodReceiptsContext()
        {
            this.Database.EnsureCreated();
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                              .UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FoodReciepts.mdf; Trusted_Connection = True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.HasOne(Ingredients => Ingredients.Receipts)
                      .WithMany(Receipts => Receipts.Ingredients)
                      .HasForeignKey(Ingredients => Ingredients.ReceiptsId);
            });

            var carb = new Receipts() { Id = 1, Name = "Carbonara", Price = 1400 };
            var bolo = new Receipts() { Id = 2, Name = "Bolognai", Price = 900 };
            var gt = new Receipts() { Id = 3, Name = "Grízes tészta", Price = 400, IsSeductive = true };
            var lasa = new Receipts() { Id = 4, Name = "Lasagne", Price = 1600, IsSeductive = true };
            var pk = new Receipts() { Id = 5, Name = "Paprikás krumpli", Price = 700 };
            var lecso = new Receipts() { Id = 6, Name = "Lecsó", Price = 850 };


            var IngredientsList = new List<Ingredients>()
            {
                // Carb
                new Ingredients() { Id = 1, Name = "Spagetti tészta", Amount = 1, ReceiptsId = carb.Id },
                new Ingredients() { Id = 2, Name = "Tojás", Amount = 4, ReceiptsId = carb.Id },
                new Ingredients() { Id = 3, Name = "Só", Amount = 1, ReceiptsId = carb.Id },
                new Ingredients() { Id = 4, Name = "Bors", Amount = 1, ReceiptsId = carb.Id },
                new Ingredients() { Id = 5, Name = "Bacon", Amount = 5, ReceiptsId = carb.Id },
                // Bolo
                new Ingredients() { Id = 6, Name = "Spagetti tészta", Amount = 1, ReceiptsId = bolo.Id },
                new Ingredients() { Id = 7, Name = "Paradicsom szósz", Amount = 3, ReceiptsId = bolo.Id },
                new Ingredients() { Id = 8, Name = "Hagyma", Amount = 1, ReceiptsId = bolo.Id },
                new Ingredients() { Id = 9, Name = "Darálthús", Amount = 1, ReceiptsId = bolo.Id },
                new Ingredients() { Id = 10, Name = "Oregánó", Amount = 1, ReceiptsId = bolo.Id },
                new Ingredients() { Id = 11, Name = "Só", Amount = 1, ReceiptsId = bolo.Id },
                new Ingredients() { Id = 12, Name = "Bors", Amount = 1, ReceiptsId = bolo.Id },
                new Ingredients() { Id = 13, Name = "Olaj", Amount = 1, ReceiptsId = bolo.Id },
                // Gt
                new Ingredients() { Id = 14, Name = "Lapos tészta", Amount = 2, ReceiptsId = gt.Id },
                new Ingredients() { Id = 15, Name = "Gríz", Amount = 2, ReceiptsId = gt.Id },
                new Ingredients() { Id = 16, Name = "Olaj", Amount = 2, ReceiptsId = gt.Id },
                new Ingredients() { Id = 17, Name = "Lekvár", Amount = 1, ReceiptsId = gt.Id },
                // Lasa
                new Ingredients() { Id = 18, Name = "Nagy lapos tészta", Amount = 2, ReceiptsId = lasa.Id },
                new Ingredients() { Id = 19, Name = "Paradicsom szósz", Amount = 3, ReceiptsId = lasa.Id },
                new Ingredients() { Id = 20, Name = "Hagyma", Amount = 1, ReceiptsId = lasa.Id },
                new Ingredients() { Id = 21, Name = "Darálthús", Amount = 1, ReceiptsId = lasa.Id },
                new Ingredients() { Id = 22, Name = "Oregánó", Amount = 1, ReceiptsId = lasa.Id },
                new Ingredients() { Id = 23, Name = "Só", Amount = 1, ReceiptsId = lasa.Id },
                new Ingredients() { Id = 24, Name = "Bors", Amount = 1, ReceiptsId = lasa.Id },
                new Ingredients() { Id = 25, Name = "Olaj", Amount = 1, ReceiptsId = lasa.Id },
                new Ingredients() { Id = 26, Name = "Besamel", Amount = 1, ReceiptsId = lasa.Id },
                new Ingredients() { Id = 27, Name = "Sajt", Amount = 1, ReceiptsId = lasa.Id },
                // PK
                new Ingredients() { Id = 28, Name = "Krumpli", Amount = 10, ReceiptsId = pk.Id },
                new Ingredients() { Id = 29, Name = "Hagyma", Amount = 1, ReceiptsId = pk.Id },
                new Ingredients() { Id = 30, Name = "Kolbász", Amount = 2, ReceiptsId = pk.Id },
                new Ingredients() { Id = 31, Name = "Fűszer paprika", Amount = 1, ReceiptsId = pk.Id },
                new Ingredients() { Id = 32, Name = "Só", Amount = 1, ReceiptsId = pk.Id },
                new Ingredients() { Id = 33, Name = "Bors", Amount = 1, ReceiptsId = pk.Id },
                new Ingredients() { Id = 34, Name = "Majoranna", Amount = 1, ReceiptsId = pk.Id },
                // Lecso
                new Ingredients() { Id = 35, Name = "Paprika", Amount = 6, ReceiptsId = lecso.Id },
                new Ingredients() { Id = 36, Name = "Paradicsom", Amount = 4, ReceiptsId = lecso.Id },
                new Ingredients() { Id = 37, Name = "Hagyma", Amount = 1, ReceiptsId = lecso.Id },
                new Ingredients() { Id = 38, Name = "Só", Amount = 1, ReceiptsId = lecso.Id },
                new Ingredients() { Id = 39, Name = "Bors", Amount = 1, ReceiptsId = lecso.Id },
            };

            modelBuilder.Entity<Receipts>().HasData(carb, bolo, gt, lasa, pk, lecso);
            modelBuilder.Entity<Ingredients>().HasData(IngredientsList);
        }
    }
}
