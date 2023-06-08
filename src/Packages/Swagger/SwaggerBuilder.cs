using Microsoft.OpenApi.Models;
using quiz_app_api.src.Core.Config;
using Swashbuckle.AspNetCore.Filters;

namespace quiz_app_api.src.Packages.Swagger
{
    public class SwaggerBuilder
    {
        private readonly WebApplicationBuilder _builder;
        private SwaggerBuilder(WebApplicationBuilder builder)
        {
            _builder = builder;
        }
        public static SwaggerBuilder ApplyBuilderContext(WebApplicationBuilder builder)
        {
            return new SwaggerBuilder(builder);
        }
        public SwaggerBuilder ApplyEndPoint()
        {
            _builder.Services.AddEndpointsApiExplorer();
            return this;
        }
        public WebApplicationBuilder ApplyConfig()
        {
            _builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", SwaggerConfig.ApplyInfo());

                // Configure Swagger to use the Authorization header
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Enter your token",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            return _builder;
        }
    }
}
