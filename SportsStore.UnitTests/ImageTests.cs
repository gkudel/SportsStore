﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;
using Moq;
using SportsStore.Domain.Abstract;
using System.Linq;
using SportsStore.WebUI.Controllers;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class ImageTests
    {
        [TestMethod]
        public void Can_Retrieve_Image_Data()
        {
            Product prod = new Product() 
            {
                ProductID = 2,
                Name = "Test",
                ImageData = new byte[1],
                ImageMimeType = "image/png"
            };
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                prod,
                new Product {ProductID = 3, Name = "P3"}
            }.AsQueryable());
            ProductController target = new ProductController(mock.Object);

            ActionResult result = target.GetImage(2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileContentResult));
            Assert.AreEqual(prod.ImageMimeType, ((FileContentResult)result).ContentType);
        }

        [TestMethod]
        public void Cannot_Retrieve_Image_Data()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"}
            }.AsQueryable());
            ProductController target = new ProductController(mock.Object);

            ActionResult result = target.GetImage(100);

            Assert.IsNull(result);
        }
    }
}
