namespace BookingApp.Application.DTOs.Groq
{
    public class BookingRequestGroqDTO
    {
        public int Id { get; set; }
        public int CoworkingId { get; set; }
        public string CoworkingName { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomType { get; set; }
        public int RoomCapacityId { get; set; }
        public int? RoomCapacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
