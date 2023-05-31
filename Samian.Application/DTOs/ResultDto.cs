using System.Net;

namespace SamianSoft.Application.DTOs
{
    public class ResultDto
    {
        public object? Data { get; set; }
        public required bool IsSuccess { get; set; }
        public required HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
