using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcModels.Infrastructure;
using MvcModels.Models;

namespace MvcModels
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //注册模型绑定值提供器
            //ValueProviderFactories.Factories.Insert(0, new CustomValueProviderFactory());

            ModelBinders.Binders.Add(typeof(AddressSummary), new AddressSummaryBinder());
        }
    }
}
