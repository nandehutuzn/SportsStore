﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllersAndAction.Controllers
{
    public class BasicController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            string controller = (string)requestContext.RouteData.Values["controller"];
            string action = (string)requestContext.RouteData.Values["action"];

            if (action.ToLower() == "redircet")
            {
                requestContext.HttpContext.Response.Redirect("/Derived/Index");
            }
            else
                requestContext.HttpContext.Response.Write(
                    $"Controller: {controller}, Action: {action}");
        }

        public void Index()
        {
            return;
        }
    }
}