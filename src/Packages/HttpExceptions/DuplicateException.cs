using System.Net;

namespace quiz_app_api.src.Packages.HttpExceptions
{
    public class DuplicateException : HttpException
    {
        public DuplicateException(string message = "Duplicate record") : base(HttpStatusCode.Conflict, ExceptionEnum.DUPLICATE, message) { }
    }
}
