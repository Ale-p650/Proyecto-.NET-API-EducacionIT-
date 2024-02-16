using System.Reflection;

namespace ProyectoIT.Middlewares
{
    public class MiddlewareCustom
    {
        string clase;

        private readonly RequestDelegate _next;
        public MiddlewareCustom(RequestDelegate next)
        {
            _next = next;
            clase = MethodBase.GetCurrentMethod().DeclaringType.FullName;
            
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await Console.Out.WriteLineAsync
                ($"Ejecucion de Middleware desde clase {clase} ANTES de Controller" );

            await _next(context);

            await Console.Out.WriteLineAsync
                ($"Ejecucion de Middleware desde clase {clase} DESPUES de Controller");
        }
    }
}
