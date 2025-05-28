using BookingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
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

            // seed

            modelBuilder.Entity<Domain.Entities.Type>().HasData(
                new Domain.Entities.Type { Id = 1, Name = "Open Space", Description = "A vibrant shared area perfect for freelancers or small teams who enjoy a collaborative atmosphere. Choose any available desk and get to work with flexibility and ease." },
                new Domain.Entities.Type { Id = 2, Name = "Private Rooms", Description = "Designed for productive meetings, workshops, or client presentations. Equipped with screens, whiteboards, and comfortable seating to keep your sessions running smoothly." },
                new Domain.Entities.Type { Id = 3, Name = "Meeting Rooms", Description = "Ideal for focused work, video calls, or small team huddles. These fully enclosed rooms offer privacy and come in a variety of sizes to fit your needs." }
            );

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { Id = 1, Name = "AC" },
                new Amenity { Id = 2, Name = "Wi-fi" },
                new Amenity { Id = 3, Name = "Gaming Console" },
                new Amenity { Id = 4, Name = "Coffee" },
                new Amenity { Id = 5, Name = "Audio Station" },
                new Amenity { Id = 6, Name = "Karaoke" }
            );

            modelBuilder.Entity<TypeAmenity>().HasData(
                new TypeAmenity { TypeId = 1, AmenityId = 1 },
                new TypeAmenity { TypeId = 1, AmenityId = 2 },
                new TypeAmenity { TypeId = 1, AmenityId = 3 },
                new TypeAmenity { TypeId = 1, AmenityId = 4 },

                new TypeAmenity { TypeId = 2, AmenityId = 1 },
                new TypeAmenity { TypeId = 2, AmenityId = 2 },
                new TypeAmenity { TypeId = 2, AmenityId = 5 },

                new TypeAmenity { TypeId = 3, AmenityId = 1 },
                new TypeAmenity { TypeId = 3, AmenityId = 2 },
                new TypeAmenity { TypeId = 3, AmenityId = 5 },
                new TypeAmenity { TypeId = 3, AmenityId = 6 }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, TypeId = 1 },
                new Room { Id = 2, TypeId = 1 },
                new Room { Id = 3, TypeId = 1 },
                new Room { Id = 4, Capacity = 10, TypeId = 3 },
                new Room { Id = 5, Capacity = 20, TypeId = 3 },
                new Room { Id = 6, Capacity = 20, TypeId = 3 },
                new Room { Id = 7, Capacity = 1, TypeId = 2 },
                new Room { Id = 8, Capacity = 2, TypeId = 2 },
                new Room { Id = 9, Capacity = 5, TypeId = 2 },
                new Room { Id = 10, Capacity = 10, TypeId = 2 },
                new Room { Id = 11, Capacity = 1, TypeId = 2 },
                new Room { Id = 12, Capacity = 2, TypeId = 2 },
                new Room { Id = 13, Capacity = 5, TypeId = 2 },
                new Room { Id = 14, Capacity = 1, TypeId = 2 },
                new Room { Id = 15, Capacity = 2, TypeId = 2 }
            );
        }
    }
}
