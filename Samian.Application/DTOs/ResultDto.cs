namespace SamianSoft.Application.DTOs
{
    public class ResultDto
    {
        public object? Data { get; set; }
        public bool IsSuccess { get; set; } = false;
        public int StatusCode { get; set; } = 400;
        public string? Message { get; set; }
    }
}
