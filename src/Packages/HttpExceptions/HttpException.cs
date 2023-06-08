using System.Net;

namespace quiz_app_api.src.Packages.HttpExceptions
{
    public class HttpException : Exception
    {
        public HttpStatusCode statusCode { get; set; }
        public object response { get; set; }

        public HttpException(HttpStatusCode statusCode, string code, string message) : base(message)
        {
            this.statusCode = statusCode;

            response = new
            {
                message,
                status = statusCode,
                code
            };
        }
    }
}
