using AssetManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetManagement.Data
{
    public static class ApplicationDbContextSeed

    {

        public static void Seed(this ApplicationDbContext context)

        {

            //context.Database.Migrate();

            if (context.Categories.Any())

            {

                return;

            }

            AddCategories(context);

            AddProducts(context);

        }

        private static void AddCategories(ApplicationDbContext context)

        {

            context.AddRange(

            new Category { Name = "Telefon" },

            new Category { Name = "Tablet" },

            new Category { Name = "Bilgisayar" },

            new Category { Name = "Televizyon" }

            );

            context.SaveChanges();

        }

        private static void AddProducts(ApplicationDbContext context)

        {

            context.AddRange(

            new Product { Title = "iPhone", Price = 4000, CategoryId = 1 }

            );

            context.SaveChanges();


        }
    }
}
