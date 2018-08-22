using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;
using System.Web.Routing;
using System.Reflection;

namespace UrlsAndRoutes.Tests
{
    [TestClass]
    public class RouteTests
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null,
            string httpMethod = "GET")
        {
            //创建模仿请求
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath)
                .Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            //创建模仿响应
            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>()))
                .Returns<string>(s => s);

            //创建使用上述请求和响应的模仿上下文
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            //返回模仿的上下文

            return mockContext.Object;
        }

        private void TestRouteMatch(string url, string controller,
            string action, object routeProperties = null, string httpMethod = "GET")
        {
            //准备
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            //动作一处理路由
            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            //断言
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }

        private bool TestIncomingRouteResult(RouteData routeResult, string controller,
            string action, object propertySet = null)
        {
            Func<object, object, bool> valCompare = (v1, v2) =>
            {
                return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;
            };

            bool result = valCompare(routeResult.Values["controller"], controller) &&
                valCompare(routeResult.Values["action"], action);

            if (propertySet != null)
            {
                PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
                foreach (PropertyInfo pi in propInfo)
                {
                    if (!(routeResult.Values.ContainsKey(pi.Name) &&
                        valCompare(routeResult.Values[pi.Name], pi.GetValue(propertySet, null))))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        private void TestRouteFail(string url)
        {
            //准备
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            //动作一处理路由
            RouteData result = routes.GetRouteData(CreateHttpContext(url));

            //断言
            Assert.IsTrue(result == null || result.Route == null);
        }

        [TestMethod]
        public void TestIncomingRoutes()
        {
            //对我们希望接收的URL进行检查
            TestRouteMatch("~/Admin/Index", "Admin", "Index");

            //检查通过片段获取的值
            TestRouteMatch("~/One/Two", "One", "Two");

            //确保太多或太少片段数不会匹配
            TestRouteFail("~/Admin/Index/Segment");
            TestRouteFail("~/Admin");
        }
    }
}
