namespace BookingApp.Application.DTOs
{
    public class OperationResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public int ErrorCode { get; set; }
        public T? Data { get; set; }
    }
}
