using System.Net;

namespace quiz_app_api.src.Packages.HttpExceptions
{
    public class BadRequestException : HttpException
    {
        public BadRequestException(string message = "Bad request") : base(HttpStatusCode.BadRequest, ExceptionEnum.BAD_REQUEST, message) { }
    }
}
