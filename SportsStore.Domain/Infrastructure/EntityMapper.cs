using AutoMapper;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Infrastructure
{
    internal static class EntityMapper
    {
        private static bool initilaized = false;
        private static object syncRoot = new Object();

        private static void Init()
        {
            lock (syncRoot)
            {
                if (!initilaized)
                {
                    Mapper.CreateMap<Product, Product>().ForMember(p => p.ProductID, opt => opt.Ignore());
                    initilaized = true;
                }
            }
        }

        internal static void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            Init();
            Mapper.Map<TSource, TDestination>(source, destination);
        }

        internal static TDestination Map<TSource, TDestination>(TSource source)
        {
            Init();
            return Mapper.Map<TSource, TDestination>(source);
        }
    }
}
