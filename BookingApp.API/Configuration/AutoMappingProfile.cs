using AutoMapper;
using BookingApp.Application.CQRS.Booking.Commands.CreateNewBooking;
using BookingApp.Application.DTOs.Booking;
using BookingApp.Application.DTOs.Booking.GetAllBookingsInfo;
using BookingApp.Application.DTOs.Booking.GetBookingForEdit;
using BookingApp.Domain.Entities;

namespace BookingApp.API.Configuration
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            // booking commands
            CreateMap<CreateNewBookingCommand, Booking>();
            CreateMap<Booking, BookingDTO>();

            // booking editing queries
            CreateMap<RoomCapacityRoomType, RoomCapacityDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoomCapacity.Id))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.RoomCapacity.Capacity));
            CreateMap<RoomType, RoomTypeWithCapacitiesDTO>();
            CreateMap<Booking, BookingWithAllRoomTypesDTO>();

            // booking page
            CreateMap<Booking, BookingWithRoomTypeDTO>()
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.Room.RoomTypeId));
            CreateMap<RoomCapacityRoomType, RoomCapacityWithRoomsDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoomCapacity.Id))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.RoomCapacity.Capacity))
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.RoomCapacity.Rooms));
            CreateMap<RoomType, RoomTypeWithCapacitiesNRoomsDTO>();
            CreateMap<Room, RoomDTO>();
            CreateMap<RoomTypeAmenity, AmenityDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AmenityId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Amenity.Name));
            CreateMap<RoomType, RoomTypeInfoWithUserBookedDTO>()
                .ForMember(dest => dest.Amenities, opt => opt.MapFrom(src => src.RoomTypeAmenities));
        }
    }
}
