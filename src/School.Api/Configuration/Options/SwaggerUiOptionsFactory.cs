using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace School.Api.Configuration.Options
{
    public static class SwaggerUiOptionsFactory
    {
        public static Action<SwaggerUIOptions> Create(IConfiguration config)
        {
            return options =>
            {
                options.DocExpansion(DocExpansion.None);
                options.SwaggerEndpoint(config["swagger:path"], "Api de Sensores");
            };
        }
    }
}
