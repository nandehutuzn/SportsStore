using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        public void Can_Paginate()
        {
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product { ProductID=1, Name="p1"},
                new Product { ProductID=2, Name="p2"},
                new Product { ProductID=3, Name="p3"},
                new Product { ProductID=4, Name="p4"},
                new Product { ProductID=5, Name="p5"},
            });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            
            //ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;
        }
    }
}
