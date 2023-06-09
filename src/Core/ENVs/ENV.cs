using quiz_app_api.src.Core.Ultils;

namespace quiz_app_api.src.Core.ENVs
{
    public class ENV
    {
        public static readonly string JWT_SECRET;
        public static readonly string EXPIRE_MINUTE;
        public static readonly string EXPIRE_DAY;
        public static readonly string CONNECTION_STRING;
        public static readonly string WORK_FACTOR;
        static ENV()
        {
            DotNetEnv.Env.Load();
            WORK_FACTOR = Environment.GetEnvironmentVariable("WORK_FACTOR") ?? "4";
            JWT_SECRET = Environment.GetEnvironmentVariable("JWT_SECRET") ?? "DDL/BmceDMg/nly7+QaW1nxKeshn7C19B8XGl0xVTHDB7OpB0";
            EXPIRE_MINUTE = Environment.GetEnvironmentVariable("EXPIRE_MINUTE") ?? "10";
            EXPIRE_DAY = Environment.GetEnvironmentVariable("EXPIRE_DAY") ?? "30";
            CONNECTION_STRING = Optional.Of(Environment.GetEnvironmentVariable("CONNECTION_STRING")).ThrowIfNotPresent(new Exception(EnvEnum.CONNECTION_STRING_NOT_FOUND)).Get();
        }
    }
}
