namespace BookingApp.Application.DTOs
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public int ErrorCode { get; set; }
    }
}
