using AutoMapper;
using BookingApp.Application.CQRS.Booking.Commands.CreateNewBooking;
using BookingApp.Application.DTOs.Booking;
using BookingApp.Application.DTOs.Booking.GetAllBookingsInfo;
using BookingApp.Application.DTOs.Booking.GetBookingForEdit;
using BookingApp.Application.DTOs.Booking.GetDataForNewBooking;
using BookingApp.Domain.Entities;

namespace BookingApp.API.Configuration
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            // base dtos
            CreateMap<Booking, BookingDTO>();
            CreateMap<RoomCapacity, RoomCapacityDTO>();
            CreateMap<Room, RoomDTO>();
            CreateMap<RoomType, RoomTypeDTO>();
            CreateMap<Amenity, AmenityDTO>();

            // junction 
            CreateMap<RoomTypeAmenity, AmenityDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Amenity.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Amenity.Name));
            CreateMap<RoomCapacityRoomType, RoomCapacityDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoomCapacity.Id))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.RoomCapacity.Capacity));

            // booking add commands
            CreateMap<CreateNewBookingCommand, Booking>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateOnly.Parse(src.StartDate)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => DateOnly.Parse(src.EndDate)))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeOnly.Parse(src.StartTime)))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => TimeOnly.Parse(src.EndTime)));

            // booking add queries
            CreateMap<RoomType, NewBookingStructureDTO>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.RoomCapacities, opt => opt.MapFrom(src => src.RoomCapacities));

            // booking editing queries
            CreateMap<RoomType, RoomTypeWithCapacitiesDTO>();
            CreateMap<Booking, BookingWithAllRoomTypesDTO>();

            // booking page
            CreateMap<Booking, BookingInfoDTO>()
                .ForMember(dest => dest.Booking, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room));
            CreateMap<RoomCapacityRoomType, RoomCapacityInfoDTO>()
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.RoomCapacity.Rooms));
            CreateMap<RoomType, BookingTypeInfoDTO>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms))
                .ForMember(dest => dest.Amenities, opt => opt.MapFrom(src => src.RoomTypeAmenities))
                .ForMember(dest => dest.RoomCapacities, opt => opt.MapFrom(src => src.RoomCapacities));
        }
    }
}
