using AutoMapper;
using BookingApp.Application.CQRS.Booking.Commands.CreateNewBooking;
using BookingApp.Application.DTOs.Booking;
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
            CreateMap<RoomType, RoomTypesForNewBookingDTO>();
            CreateMap<Booking, BookingEditDTO>();
        }
    }
}
