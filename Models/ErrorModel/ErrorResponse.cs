using Microsoft.AspNetCore.Identity;

namespace Models.ErrorModel
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Description { get; set; }
    }
}
