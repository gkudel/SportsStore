using AutoMapper;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Entities.Product> Products
        {
            get { return context.Products; }
        }


        public void SaveProduct(Entities.Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {                
                Entities.Product dbEntry = context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    EntityMapper.Map<Entities.Product, Entities.Product>(product, dbEntry);
                }
            }
            context.SaveChanges();
        }
    }
}
