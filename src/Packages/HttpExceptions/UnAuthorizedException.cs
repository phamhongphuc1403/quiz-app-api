using System.Net;

namespace quiz_app_api.src.Packages.HttpExceptions
{
    public class UnAuthorizedException : HttpException
    {
        public UnAuthorizedException(string message = "Invalid access token") : base(HttpStatusCode.Unauthorized, ExceptionEnum.UNAUTHORIZED, message) { }
    }
}
