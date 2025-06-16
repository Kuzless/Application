using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Workspace;

namespace BookingApp.Application.CQRS.Workspace.Queries.GetAllCoworkingsInfo
{
    public class GetAllCoworkingsInfoQueryDTO
    {
        public CoworkingDTO Coworking { get; set; }
        public CityDTO City { get; set; }
        public AddressDTO Address { get; set; }
        public List<RoomTypeWithRoomsDTO> RoomTypesWithRooms { get; set; }
    }
}
