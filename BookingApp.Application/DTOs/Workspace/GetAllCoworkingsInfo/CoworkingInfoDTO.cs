namespace BookingApp.Application.DTOs.Workspace.GetAllCoworkingsInfo
{
    public class CoworkingInfoDTO
    {
        public CoworkingDTO Coworking { get; set; }
        public CityDTO City { get; set; }
        public AddressDTO Address { get; set; }
        public List<RoomTypeWithRoomsDTO> RoomTypesWithRooms { get; set; }
    }
}
