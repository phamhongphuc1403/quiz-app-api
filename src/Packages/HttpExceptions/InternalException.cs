using System.Net;

namespace quiz_app_api.src.Packages.HttpExceptions
{
    public class InternalException : HttpException
    {
        public InternalException(string message = "Internal server error") : base(HttpStatusCode.InternalServerError, ExceptionEnum.INTERNAL, message) { }
    }
}
