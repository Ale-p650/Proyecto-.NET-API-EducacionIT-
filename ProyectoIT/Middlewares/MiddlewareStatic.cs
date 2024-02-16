using Model.Entidades;
using Repositorio.Clases_Servicio;
using System.Reflection;

namespace ProyectoIT.Middlewares
{
    public static class MiddlewareStatic
    {
        

        public static IApplicationBuilder MetodoRun(this IApplicationBuilder app)
        {
            var clase = MethodBase.GetCurrentMethod().DeclaringType.FullName;

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Middleware Terminal ejecutado desde  {clase}");
                
            });
            return app;
        }

        public static IApplicationBuilder MetodoUseAndRun(this IApplicationBuilder app)
        {
            var clase = MethodBase.GetCurrentMethod().DeclaringType.FullName;

            app.Use(async (context,next) =>
            {
                await context.Response.WriteAsync($"Middleware ejecutado desde  {clase}");
                await next.Invoke(context);
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"\nMiddleware Terminal ejecutado desde  {clase}");

            });
            return app;
        }

        public static IApplicationBuilder MetodoLOGS(this IApplicationBuilder app)
        {
            

            app.Use(async (context, next) =>
            {
                using(var scope = Configuration.GetProvider().CreateScope())
                {
                    var logRepo = scope.ServiceProvider.GetRequiredService<MiddlewareLogsREPO>();

                    MiddlewareLogs log = new MiddlewareLogs();

                        log.Date = DateTime.UtcNow;
                        log.Method = context.Request.Method;

                        await logRepo.InsertAsync(log);
                }

                 await next.Invoke(context);
            });

            
            return app;
        }
    }
}
