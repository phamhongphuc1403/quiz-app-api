using quiz_app_api.src.Core.ENVs;

namespace quiz_app_api.src.Core.Modules.Auth.Service
{
    public class BCryptService
    {
        private readonly int _workFactor;
        public BCryptService()
        {
            _workFactor = Convert.ToInt32(ENV.WORK_FACTOR);
        }
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, _workFactor);
        }
        public bool Verify(string password, string harsedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, harsedPassword);
        }
    }
}
