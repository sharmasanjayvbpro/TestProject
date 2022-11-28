using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestProject.Filter
{
    public class AppException : FilterAttribute, IExceptionFilter

    {

        Logger _logger = LogManager.GetCurrentClassLogger();
        public void OnException(ExceptionContext filterContext)
        {
            _logger.Error(filterContext.Exception.ToString());

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
        };
            filterContext.ExceptionHandled = true;
        }
    }
}