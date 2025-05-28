using BookingApp.API.Interfaces;
using BookingApp.API.Services;
using BookingApp.Application.CQRS.Booking.Commands.CreateNewBooking;
using BookingApp.Application.Interfaces;
using BookingApp.Application.Services.ErrorHandler;
using BookingApp.Domain.Interfaces;
using BookingApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.API.Configuration
{
    public static class ConfigureApplication
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["DbConnectionString"]);
            });

            builder.Services.AddAutoMapper(typeof(AutoMappingProfile));
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateNewBookingCommand).Assembly);
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IApiResponseHandler, ApiResponseHandler>();

            builder.Services.AddKeyedScoped<IResponseHandlerService, BookingResponseHandlerService>("booking");
        }
    }
}
