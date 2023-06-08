using System.Net;

namespace quiz_app_api.src.Packages.HttpExceptions
{
    public class ForbiddenException : HttpException
    {
        public ForbiddenException(string message = "You don't have permission to access this resource") : base(HttpStatusCode.Forbidden, ExceptionEnum.FORBIDDEN, message) { }
    }
}
