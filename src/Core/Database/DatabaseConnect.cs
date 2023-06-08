using Microsoft.EntityFrameworkCore;
using quiz_app_api.src.Core.ENVs;

namespace quiz_app_api.src.Core.Database
{
    public class DatabaseConnect
    {
        private readonly string _connectionString;
        private readonly WebApplicationBuilder _builder;
        private DatabaseConnect(WebApplicationBuilder builder)
        {
            _connectionString = ENV.CONNECTION_STRING;
            _builder = builder;
        }
        public static DatabaseConnect ApplyBuilderContext(WebApplicationBuilder builder)
        {
            return new DatabaseConnect(builder);
        }
        public WebApplicationBuilder ApplyDbContext()
        {
            _builder.Services.AddDbContext<AppDbContext>(option => {
                option.UseSqlServer(_connectionString);
            });

            return _builder;
        }
    }
}
