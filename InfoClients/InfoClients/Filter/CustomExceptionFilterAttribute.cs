using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Net.Http;

namespace InfoClients.Api.Filter
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class CustomExceptionFilterAttribute : ExceptionFilterAttribute, IActionFilter
    {
        private readonly ILog logger;

        public CustomExceptionFilterAttribute(ILog logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Metodo intencionalmente vacío por la implemetación de la interfaz
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context == null)
            {
                throw new InvalidProgramException("No existe un contexto en la aplicación");
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        public override void OnException(ExceptionContext context)
        {

            if (context == null)
            {
                throw new InvalidProgramException("No existe un contexto en la aplicación");
            }

            string errorMessage = null;
            string errorMessageLog = null;
            int hashCode = HttpStatusCode.InternalServerError.GetHashCode();
            var exceptionType = context.Exception;

            switch (exceptionType)
            {
                case ArgumentNullException argumentNullException:
                case ArgumentException argumentException:
                    errorMessageLog = errorMessage = string.IsNullOrWhiteSpace(context.Exception?.InnerException?.Message) ? context.Exception.Message : context.Exception.InnerException.Message;
                    hashCode = HttpStatusCode.BadRequest.GetHashCode();
                    break;
                default:
                    errorMessageLog = errorMessage = string.IsNullOrWhiteSpace(context.Exception?.InnerException?.Message) ? context.Exception.Message : context.Exception.InnerException.Message;
                    hashCode = HttpStatusCode.InternalServerError.GetHashCode();
                    break;
            }

            logger.Error($"Ha ocurrido un error en el servicio {context.HttpContext.Request.Path}: {errorMessageLog}", context.Exception);
            context.Result = new ContentResult
            {
                Content = errorMessage,
                ContentType = "text/html; charset=utf-8",
                StatusCode = hashCode
            };
        }

        private int GetStatusCodeFromCustomRestClientException(HttpResponseMessage httpResponseMessage)
        {
            if (HttpStatusCode.Unauthorized.Equals(httpResponseMessage.StatusCode))
            {
                return HttpStatusCode.InternalServerError.GetHashCode();
            }

            return httpResponseMessage.StatusCode.GetHashCode();
        }

        private string GetContentFromCustomRestClientException(HttpResponseMessage httpResponseMessage)
        {
            if (HttpStatusCode.Unauthorized.Equals(httpResponseMessage.StatusCode))
            {
                return $"Ocurrió un error al realiza la peticion {httpResponseMessage.RequestMessage.Method} " +
                    $"al servicio {httpResponseMessage.RequestMessage.RequestUri}: {httpResponseMessage.StatusCode.GetHashCode()}";
            }

            return httpResponseMessage.Content.ReadAsStringAsync().Result;
        }
    }
}
