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
                new Product { Name = "Football", Price = 25 },
                new Product { Name = "Surf board", Price = 179 },
                new Product { Name = "Running shoes", Price = 95 }
            };
            products.ForEach(p => context.Products.AddOrUpdate<Product>(pr => pr.Name, p));
        }
    }
}
