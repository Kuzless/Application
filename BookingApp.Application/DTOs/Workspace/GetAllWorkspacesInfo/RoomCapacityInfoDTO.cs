namespace BookingApp.Application.DTOs.Workspace.GetAllWorkspacesInfo
{
    public class RoomCapacityInfoDTO
    {
        public RoomCapacityDTO RoomCapacity { get; set; }
        public List<RoomDTO> Rooms { get; set; }
    }
}
