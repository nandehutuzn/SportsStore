using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class CartTests
    {
        public void Can_Add_New_Lines()
        {
            Product p1 = new Product() { ProductID = 1, Name = "p1", Price = 5 };
            Product p2 = new Product() { ProductID = 2, Name = "p2", Price = 8 };

            Cart target = new Cart();
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);

            CartLine[] results = target.Lines.ToArray();

            //断言
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0], p1);
            Assert.AreEqual(results[1], p2);
        }
    }
}
