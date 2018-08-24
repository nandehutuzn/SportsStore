using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class CustomAuthAttribute : AuthorizeAttribute
    {
        private bool _localAllowed;

        public CustomAuthAttribute(bool allowedParam)
        {
            _localAllowed = allowedParam;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.IsLocal)
                return _localAllowed;
            else
                return true;
        }
    }
}