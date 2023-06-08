using Microsoft.AspNetCore.Authentication.JwtBearer;
using quiz_app_api.src.Core.Database;
using quiz_app_api.src.Core.Modules.Auth.Service;
using quiz_app_api.src.Packages.Swagger;

namespace quiz_app_api.src.Core.Config
{
    public class AppBundle
    {
        private WebApplicationBuilder _builder;
        private readonly JwtService jwtSetvice;
        private AppBundle(WebApplicationBuilder builder)
        {
            _builder = builder;
            jwtSetvice = new JwtService();
        }
        public static AppBundle ApplyBuilderContext(WebApplicationBuilder builder)
        {
            return new AppBundle(builder);
        }
        public AppBundle Init()
        {
            _builder.Services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = 50 * 1024 * 1024; //50MB
            });
            return this;
        }
        public AppBundle ApplySwagger()
        {
            _builder = SwaggerBuilder
                .ApplyBuilderContext(_builder)
                .ApplyEndPoint()
                .ApplyConfig();
            return this;
        }
        public AppBundle ApplyAuth()
        {
            _builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = jwtSetvice.Validator();
                    }
                );
            return this;
        }
        public AppBundle ApplyDbContext()
        {
            _builder = DatabaseConnect
                .ApplyBuilderContext(_builder)
                .ApplyDbContext();
            return this;
        }
        public AppBundle ApplyControllers()
        {
            _builder.Services.AddControllers();
            return this;
        }
        public void Run()
        {
            var app = _builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
