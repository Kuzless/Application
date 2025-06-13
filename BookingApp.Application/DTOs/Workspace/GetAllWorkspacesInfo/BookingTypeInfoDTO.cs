namespace BookingApp.Application.DTOs.Workspace.GetAllWorkspacesInfo
{
    public class BookingTypeInfoDTO
    {
        public RoomTypeDTO RoomType { get; set; }
        public List<RoomDTO> Rooms { get; set; }
        public List<RoomCapacityDTO> RoomCapacities { get; set; }
        public List<AmenityDTO> Amenities { get; set; }
        public List<BookingInfoDTO> BookingInfos { get; set; }
    }
}
