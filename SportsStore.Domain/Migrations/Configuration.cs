namespace SportsStore.Domain.Migrations
{
    using SportsStore.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SportsStore.Domain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SportsStore.Domain.Concrete.EFDbContext context)
        {
            var products = new List<Product> {
                new Product { Name = "Kayak", Description="A boat for a person", Category="Watersports", Price = 275 },
                new Product { Name = "Lifejacket", Description="Protective and fashionable", Category="Watersports", Price = 48.95M },
                new Product { Name = "Soccer Ball", Description="FIFA-approved size and weight", Category="Soccer", Price = 19.50M },
                new Product { Name = "Corner Flags", Description="Give your playing field a professional touch", Category="Soccer", Price = 34.95M },
                new Product { Name = "Stadium", Description="Flat-packed 35.000-seat stadium", Category="Soccer", Price = 79500.00M },
                new Product { Name = "Thinking Cap", Description="Improve your brain efficiency by 75%", Category="Chess", Price = 16.00M }
            };
            products.ForEach(p => context.Products.AddOrUpdate<Product>(pr => pr.Name, p));
        }
    }
}
