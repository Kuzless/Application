using BookingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Domain.Entities.Type> Types { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<TypeAmenity> TypeAmenties { get; set; }
        public DatabaseContext() : base() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.Type>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<Amenity>().HasIndex(a => a.Name).IsUnique();

            modelBuilder.Entity<TypeAmenity>().HasKey(ta => new { ta.TypeId, ta.AmenityId });
            modelBuilder.Entity<TypeAmenity>().HasOne(ta => ta.Type)
                .WithMany(t => t.TypeAmenities)
                .HasForeignKey(ta => ta.TypeId);
            modelBuilder.Entity<TypeAmenity>().HasOne(ta => ta.Amenity)
                .WithMany(a => a.TypeAmenities)
                .HasForeignKey(ta => ta.AmenityId);
        }
    }
}
