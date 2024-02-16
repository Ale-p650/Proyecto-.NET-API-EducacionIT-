using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace ProyectoIT.Filtros
{
    public class FiltroExcepcion : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var response = new { error = "Error Manejado desde EL FILTRO DE EXCEPCIONES" };
            var payload = JsonConvert.SerializeObject(response);

            context.Result = new ContentResult()
            {
                Content = payload,
                ContentType = "application/json",
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            context.ExceptionHandled = true;
        }
    }
}
