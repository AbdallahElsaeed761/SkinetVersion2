
namespace API.Error
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Request",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => "An Error Occured",
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; } 
    }
}
