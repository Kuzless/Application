namespace BookingApp.Application.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
