using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace quiz_app_api.src.Core.Config
{
    public class SwaggerConfig
    {
        public static OpenApiInfo ApplyInfo()
        {
            return new OpenApiInfo
            {
                Title = "Quiz app API",
                Version = "1.0.0",
                Description = "API for a quiz application",
                Contact = new OpenApiContact
                {
                    Name = "Phuc",
                    Email = "phamhongphuc1403@gmail.com"
                }
            };
        }
        public static OpenApiSecurityScheme ApiSecurityScheme()
        {
            return new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Enter your token",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
        }
    }
}
