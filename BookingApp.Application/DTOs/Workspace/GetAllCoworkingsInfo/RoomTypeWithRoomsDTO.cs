namespace BookingApp.Application.DTOs.Workspace.GetAllCoworkingsInfo
{
    public class RoomTypeWithRoomsDTO
    {
        public RoomTypeDTO RoomType { get; set; }
        public List<RoomDTO> Rooms { get; set; }
    }
}
