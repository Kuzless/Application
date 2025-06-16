using AutoMapper;
using BookingApp.Application.CQRS.Booking.Commands.CreateNewBooking;
using BookingApp.Application.CQRS.Booking.Commands.UpdateBooking;
using BookingApp.Application.CQRS.Booking.Queries.GetDataForNewBooking;
using BookingApp.Application.CQRS.Booking.Queries.GetUserBookingsInfo;
using BookingApp.Application.CQRS.Workspace.Queries.GetAllCoworkingsInfo;
using BookingApp.Application.CQRS.Workspace.Queries.GetAllWorkspacesInfo;
using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.Booking;
using BookingApp.Application.DTOs.Booking.GetBookingForEdit;
using BookingApp.Application.DTOs.Groq;
using BookingApp.Application.DTOs.Workspace;
using BookingApp.Domain.Entities;

namespace BookingApp.API.Configuration
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            // base dtos
            CreateMap<City, CityDTO>();
            CreateMap<Address, AddressDTO>();
            CreateMap<Coworking, CoworkingDTO>();
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

            // booking add command
            CreateMap<CreateNewBookingCommand, Booking>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateOnly.Parse(src.StartDate)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => DateOnly.Parse(src.EndDate)))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeOnly.Parse(src.StartTime)))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => TimeOnly.Parse(src.EndTime)));

            // booking update command
            CreateMap<UpdateBookingCommand, Booking>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookingId))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateOnly.Parse(src.StartDate)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => DateOnly.Parse(src.EndDate)))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeOnly.Parse(src.StartTime)))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => TimeOnly.Parse(src.EndTime)));

            // booking add queries
            CreateMap<RoomType, RoomTypeWithCapacitiesDTO>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.RoomCapacities, opt => opt.MapFrom(src => src.RoomCapacities));

            // booking editing queries
            CreateMap<Booking, GetBookingForEditQueryDTO>()
                .ForMember(dest => dest.Booking, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.Room.RoomType))
                .ForMember(dest => dest.RoomCapacity, opt => opt.MapFrom(src => src.Room.RoomCapacity));

            // booking page
            CreateMap<Booking, BookingWithRoomDTO>()
                .ForMember(dest => dest.Booking, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room));
            CreateMap<RoomType, GetAllWorkspacesInfoQueryDTO>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms))
                .ForMember(dest => dest.Amenities, opt => opt.MapFrom(src => src.RoomTypeAmenities))
                .ForMember(dest => dest.RoomCapacities, opt => opt.MapFrom(src => src.RoomCapacities));

            // user bookings page
            CreateMap<Room, BookingInfoDTO>()
                .ForMember(dest => dest.Booking, opt => opt.MapFrom(src => src.Bookings))
                .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType))
                .ForMember(dest => dest.RoomCapacity, opt => opt.MapFrom(src => src.RoomCapacity));
            CreateMap<Coworking, GetUserBookingsInfoQueryDTO>()
                .ForMember(dest => dest.Coworking, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.Rooms));

            // coworking page
            CreateMap<Coworking, GetAllCoworkingsInfoQueryDTO>()
                .ForMember(dest => dest.Coworking, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

            // groq
            CreateMap<Booking, GroqBookingDataDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CoworkingName, opt => opt.MapFrom(src => src.Room.Coworking.Name))
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.Room.RoomType.Type))
                .ForMember(dest => dest.RoomCapacity, opt => opt.MapFrom(src => src.Room.RoomCapacity.Capacity))
                .ForMember(dest => dest.CoworkingId, opt => opt.MapFrom(src => src.Room.Coworking.Id))
                .ForMember(dest => dest.RoomTypeId, opt => opt.MapFrom(src => src.Room.RoomType.Id))
                .ForMember(dest => dest.RoomCapacityId, opt => opt.MapFrom(src => src.Room.RoomCapacity.Id))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToDateTime(src.StartTime)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.ToDateTime(src.EndTime)));
        }
    }
}
