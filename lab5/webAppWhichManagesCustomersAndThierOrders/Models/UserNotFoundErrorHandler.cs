using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webAppWhichManagesCustomersAndThierOrders.Models
{
    public class UserNotFoundErrorHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "CustomerNotFoundView"
            };
            base.OnException(filterContext);
        }
    }
}