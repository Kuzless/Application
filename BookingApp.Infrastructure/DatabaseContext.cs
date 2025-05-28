using BookingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomTypeAmenity> RoomTypeAmenties { get; set; }
        public DbSet<RoomCapacity> RoomCapacities { get; set; }
        public DbSet<RoomCapacityRoomType> RoomCapacityRoomTypes { get; set; }
        public DatabaseContext() : base() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoomType>().HasIndex(t => t.Type).IsUnique();
            modelBuilder.Entity<Amenity>().HasIndex(a => a.Name).IsUnique();
            modelBuilder.Entity<RoomCapacity>().HasIndex(c => c.Capacity).IsUnique();

            modelBuilder.Entity<RoomTypeAmenity>().HasKey(ta => new { ta.RoomTypeId, ta.AmenityId });
            modelBuilder.Entity<RoomTypeAmenity>().HasOne(ta => ta.RoomType)
                .WithMany(t => t.RoomTypeAmenities)
                .HasForeignKey(ta => ta.RoomTypeId);
            modelBuilder.Entity<RoomTypeAmenity>().HasOne(ta => ta.Amenity)
                .WithMany(a => a.RoomTypeAmenities)
                .HasForeignKey(ta => ta.AmenityId);

            modelBuilder.Entity<RoomCapacityRoomType>().HasKey(ct => new { ct.RoomCapacityId, ct.RoomTypeId });
            modelBuilder.Entity<RoomCapacityRoomType>().HasOne(ct => ct.RoomCapacity)
                .WithMany(c => c.RoomTypes)
                .HasForeignKey(ct => ct.RoomCapacityId);
            modelBuilder.Entity<RoomCapacityRoomType>().HasOne(ct => ct.RoomType)
                .WithMany(t => t.RoomCapacities)
                .HasForeignKey(ct => ct.RoomTypeId);

            // seed

            modelBuilder.Entity<RoomType>().HasData(
                new RoomType { Id = 1, Type = "Open Space", Description = "A vibrant shared area perfect for freelancers or small teams who enjoy a collaborative atmosphere. Choose any available desk and get to work with flexibility and ease." },
                new RoomType { Id = 2, Type = "Private Rooms", Description = "Designed for productive meetings, workshops, or client presentations. Equipped with screens, whiteboards, and comfortable seating to keep your sessions running smoothly." },
                new RoomType { Id = 3, Type = "Meeting Rooms", Description = "Ideal for focused work, video calls, or small team huddles. These fully enclosed rooms offer privacy and come in a variety of sizes to fit your needs." }
            );

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { Id = 1, Name = "AC" },
                new Amenity { Id = 2, Name = "Wi-fi" },
                new Amenity { Id = 3, Name = "Gaming Console" },
                new Amenity { Id = 4, Name = "Coffee" },
                new Amenity { Id = 5, Name = "Audio Station" },
                new Amenity { Id = 6, Name = "Karaoke" }
            );

            modelBuilder.Entity<RoomCapacity>().HasData(
                new RoomCapacity { Id = 1, Capacity = 1 },
                new RoomCapacity { Id = 2, Capacity = 2 },
                new RoomCapacity { Id = 3, Capacity = 5 },
                new RoomCapacity { Id = 4, Capacity = 10 },
                new RoomCapacity { Id = 5, Capacity = 20 }
            );

            modelBuilder.Entity<RoomCapacityRoomType>().HasData(
                new RoomCapacityRoomType { RoomCapacityId = 1, RoomTypeId = 2 },
                new RoomCapacityRoomType { RoomCapacityId = 2, RoomTypeId = 2 },
                new RoomCapacityRoomType { RoomCapacityId = 3, RoomTypeId = 2 },
                new RoomCapacityRoomType { RoomCapacityId = 4, RoomTypeId = 2 },
                new RoomCapacityRoomType { RoomCapacityId = 4, RoomTypeId = 3 },
                new RoomCapacityRoomType { RoomCapacityId = 5, RoomTypeId = 3 }
            );

            modelBuilder.Entity<RoomTypeAmenity>().HasData(
                new RoomTypeAmenity { RoomTypeId = 1, AmenityId = 1 },
                new RoomTypeAmenity { RoomTypeId = 1, AmenityId = 2 },
                new RoomTypeAmenity { RoomTypeId = 1, AmenityId = 3 },
                new RoomTypeAmenity { RoomTypeId = 1, AmenityId = 4 },

                new RoomTypeAmenity { RoomTypeId = 2, AmenityId = 1 },
                new RoomTypeAmenity { RoomTypeId = 2, AmenityId = 2 },
                new RoomTypeAmenity { RoomTypeId = 2, AmenityId = 5 },

                new RoomTypeAmenity { RoomTypeId = 3, AmenityId = 1 },
                new RoomTypeAmenity { RoomTypeId = 3, AmenityId = 2 },
                new RoomTypeAmenity { RoomTypeId = 3, AmenityId = 5 },
                new RoomTypeAmenity { RoomTypeId = 3, AmenityId = 6 }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, RoomTypeId = 1 },
                new Room { Id = 2, RoomTypeId = 1 },
                new Room { Id = 3, RoomTypeId = 1 },
                new Room { Id = 4, RoomCapacityId = 1, RoomTypeId = 3 },
                new Room { Id = 5, RoomCapacityId = 5, RoomTypeId = 3 },
                new Room { Id = 6, RoomCapacityId = 5, RoomTypeId = 3 },
                new Room { Id = 7, RoomCapacityId = 1, RoomTypeId = 2 },
                new Room { Id = 8, RoomCapacityId = 2, RoomTypeId = 2 },
                new Room { Id = 9, RoomCapacityId = 3, RoomTypeId = 2 },
                new Room { Id = 10, RoomCapacityId = 4, RoomTypeId = 2 },
                new Room { Id = 11, RoomCapacityId = 1, RoomTypeId = 2 },
                new Room { Id = 12, RoomCapacityId = 2, RoomTypeId = 2 },
                new Room { Id = 13, RoomCapacityId = 3, RoomTypeId = 2 },
                new Room { Id = 14, RoomCapacityId = 1, RoomTypeId = 2 },
                new Room { Id = 15, RoomCapacityId = 2, RoomTypeId = 2 }
            );
        }
    }
}
