namespace BookingApp.Application.DTOs.Workspace
{
    public class RoomTypeWithRoomsDTO
    {
        public RoomTypeDTO RoomType { get; set; }
        public List<RoomDTO> Rooms { get; set; }
    }
}
