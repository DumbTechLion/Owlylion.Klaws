using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Owlylion.Klaws.DataAccessLayer.Exceptions;
using Owlylion.Klaws.Web.Models;

namespace Owlylion.Klaws.Web.Filters
{
    public class KlawsApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            KlawsApiError apiError;
            if (context.Exception is EntityNotFoundException exception)
            {
#if !DEBUG
                context.Exception = null;
                var msg = "The asked ressource does not exist.";
#else
                var msg = exception.Message;
#endif
                apiError = new KlawsApiError(404, msg);
                context.HttpContext.Response.StatusCode = 404;
            }
            else
            {
#if !DEBUG
                var msg = "An unhandled error occurred.";
#else
                var msg = context.Exception.GetBaseException().Message;
#endif

                apiError = new KlawsApiError(500, msg);
                context.HttpContext.Response.StatusCode = 500;
            }
            
            context.Result = new JsonResult(apiError);
            base.OnException(context);
        }
    }
}
