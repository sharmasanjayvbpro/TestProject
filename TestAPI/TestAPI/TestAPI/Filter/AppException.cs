using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestAPI.Models;

namespace TestAPI.Filter
{
    //Filter to log exception
    public class AppException : ActionFilterAttribute, IExceptionFilter
    {
        Logger _logger = LogManager.GetCurrentClassLogger();
        public void OnException(ExceptionContext context)
        {
            _logger.Error("Error While Saving Details To File  : " + context.Exception.ToString());
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = Convert.ToInt32(ProjectConstants.StatusCodeBadRequest);
            
            //Return the response to client
            context.Result = new ObjectResult(new APIResponse()
            {   version = ProjectConstants.version, statuscode = ProjectConstants.StatusCodeBadRequest,
                message = context.Exception.Message,
                timestamp = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            });

        }
    }
}