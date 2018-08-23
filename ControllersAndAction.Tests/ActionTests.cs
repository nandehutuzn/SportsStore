using System;
using System.Web.Mvc;
using ControllersAndAction.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllersAndAction.Tests
{
    [TestClass]
    public class ActionTests
    {
        [TestMethod]
        public void ControllerTest()
        {
            ExampleController target = new ExampleController();

            ViewResult result = target.Index();

            Assert.AreEqual("Homepage", result.ViewName);
        }
    }
}
