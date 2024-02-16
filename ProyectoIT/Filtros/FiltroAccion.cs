using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Model.Entidades;
using Repositorio.Clases_Servicio;

namespace ProyectoIT.Filtros
{
    public class FiltroAccion :  ActionFilterAttribute
    {
         
        public  override  void OnActionExecuting(ActionExecutingContext context)
        {
            using(var scope = Configuration.GetProvider().CreateScope())
            {
                var filtroLog = scope.ServiceProvider.GetRequiredService<FiltroLogsREPO>();

                FiltroLogs log = new FiltroLogs()
                {
                    Action = context.ActionDescriptor.DisplayName,
                    Controller = context.Controller.ToString(),
                    Date = DateTime.Now


                };

                 filtroLog.InsertAsync(log);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Se ejecutó Action {context.ActionDescriptor.DisplayName}" +
                $" desde el Controller {context.Controller.ToString} " +
                $" Hora {DateTime.Now}"+
                $" Con resultado {context.HttpContext.Response.StatusCode}");
        }
    }
}
