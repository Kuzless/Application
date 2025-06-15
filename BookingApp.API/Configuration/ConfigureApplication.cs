using BookingApp.API.Interfaces;
using BookingApp.API.Services;
using BookingApp.Application.CQRS.Booking.Commands.CreateNewBooking;
using BookingApp.Application.Interfaces;
using BookingApp.Application.Interfaces.Booking;
using BookingApp.Domain.Interfaces;
using BookingApp.Infrastructure;
using BookingApp.Infrastructure.Services;
using BookingApp.Infrastructure.Services.Booking;
using BookingApp.Infrastructure.Services.ResponseHandling;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.API.Configuration
{
    public static class ConfigureApplication
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:MSSQLDb"]);
                //options.UseNpgsql(builder.Configuration["ConnectionStrings:PostgresDb"]);
            });

            builder.Services.AddAutoMapper(typeof(AutoMappingProfile));
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateNewBookingCommand).Assembly);
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IApiResponseHandler, ApiResponseHandler>();

            builder.Services.AddScoped<IGroqBookingService, GroqBookingService>();
            builder.Services.AddScoped<IBookingCommandService, BookingCommandService>();

            builder.Services.AddKeyedScoped<IResponseHandlerService, BookingResponseHandlerService>("booking");
            builder.Services.AddKeyedScoped<IResponseHandlerService, WorkspaceResponseHandlerService>("workspace");

            builder.Services.AddHttpClient<IGroqClient, GroqClient>();
        }
    }
}
