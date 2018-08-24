﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Views.Infrastructure
{
    public class DebugDataViewEngine : IViewEngine
    {
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            return new ViewEngineResult(new[] { "No View (Debug Data View Engine --- FindPartialView)" });
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (viewName == "DebugData")
                return new ViewEngineResult(new DebugDataView(), this);
            else
                return new ViewEngineResult(new string[] { "No View (Debug Data View Engine)" });
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
           
        }
    }
}