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
                cfg.RegisterServicesFromAssemblyContaining<Program>();
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
