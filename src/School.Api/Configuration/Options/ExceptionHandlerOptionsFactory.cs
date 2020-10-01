using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace School.Api.Configuration.Options
{
    public static class ExceptionHandlerOptionsFactory
    {
        public static ExceptionHandlerOptions Create()
        {
            return new ExceptionHandlerOptions
            {
                ExceptionHandler = Handle,
                ExceptionHandlingPath = null
            };
        }

        private static async Task Handle(this HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            context.Response.ContentType = "application/json";
            var ex = context.Features.Get<IExceptionHandlerPathFeature>();
            var err = new { Message = ex?.Error.Message };
            var result = JsonConvert.SerializeObject(err);
            await context.Response.WriteAsync(result).ConfigureAwait(false);
        }
    }
}
