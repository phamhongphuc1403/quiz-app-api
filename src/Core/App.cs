using quiz_app_api.src.Core.Config;

AppBundle
    .ApplyBuilderContext(WebApplication.CreateBuilder(args))
    .Init()
    .ApplySwagger()
    .ApplyAuth()
    .ApplyDbContext()
    .ApplyControllers()
    .Run();
