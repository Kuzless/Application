using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Workspace;

namespace BookingApp.Application.CQRS.Workspace.Queries.GetAllWorkspacesInfo
{
    public class GetAllWorkspacesInfoQueryDTO
    {
        public RoomTypeDTO RoomType { get; set; }
        public List<RoomDTO> Rooms { get; set; }
        public List<RoomCapacityDTO> RoomCapacities { get; set; }
        public List<AmenityDTO> Amenities { get; set; }
        public List<BookingWithRoomDTO> BookingInfos { get; set; }
    }
}
