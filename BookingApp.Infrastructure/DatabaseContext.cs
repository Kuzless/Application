using BookingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Coworking> Coworkings { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomTypeAmenity> RoomTypeAmenties { get; set; }
        public DbSet<RoomCapacity> RoomCapacities { get; set; }
        public DbSet<RoomCapacityRoomType> RoomCapacityRoomTypes { get; set; }
        public DatabaseContext() : base() {}
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoomType>().HasIndex(t => t.Type).IsUnique();
            modelBuilder.Entity<Amenity>().HasIndex(a => a.Name).IsUnique();
            modelBuilder.Entity<RoomCapacity>().HasIndex(c => c.Capacity).IsUnique();
            modelBuilder.Entity<City>().HasIndex(c => c.Name).IsUnique();

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

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Kyiv" },
                new City { Id = 2, Name = "Lviv" },
                new City { Id = 3, Name = "Dnipro" }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, CityId = 1, Street = "Khreshchatyk St", HouseNumber = "12" },
                new Address { Id = 2, CityId = 1, Street = "Velyka Vasylkivska St", HouseNumber = "7" },
                new Address { Id = 3, CityId = 2, Street = "Svobody Avenue", HouseNumber = "5" },
                new Address { Id = 4, CityId = 2, Street = "Halytska St", HouseNumber = "14" },
                new Address { Id = 5, CityId = 3, Street = "Troitska Square", HouseNumber = "4" }
            );

            modelBuilder.Entity<Coworking>().HasData(
                new Coworking { Id = 1, Name = "UrbanSpace Kyiv", Description = "A modern coworking space in the heart of Kyiv with high-speed internet and flexible workstations.", AddressId = 1 },
                new Coworking { Id = 2, Name = "HiveHub", Description = "Creative hub for freelancers and startups, located near central metro lines in Kyiv.", AddressId = 2 },
                new Coworking { Id = 3, Name = "Lviv Loft", Description = "Industrial-style coworking in Lviv offering 24/7 access and cozy meeting rooms.", AddressId = 3 },
                new Coworking { Id = 4, Name = "Galician Space", Description = "Coworking in historic Lviv with a focus on tech startups and events.", AddressId = 4 },
                new Coworking { Id = 5, Name = "Dnipro Works", Description = "Spacious coworking center in Dnipro with private offices and open desks.", AddressId = 5 }
            );

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

            var rooms = new List<Room>();
            int i = 1;
            // seeding desks
            for (; i <= 100; i++)
            {
                if (i < 21)
                {
                    rooms.Add(new Room { Id = i, RoomTypeId = 1, CoworkingId = 1 });
                }
                else if (i < 40)
                {
                    rooms.Add(new Room { Id = i, RoomTypeId = 1, CoworkingId = 2 });
                }
                else if (i < 60)
                {
                    rooms.Add(new Room { Id = i, RoomTypeId = 1, CoworkingId = 3 });
                }
                else if (i <= 82)
                {
                    rooms.Add(new Room { Id = i, RoomTypeId = 1, CoworkingId = 4 });
                }
                else
                {
                    rooms.Add(new Room { Id = i, RoomTypeId = 1, CoworkingId = 5 });
                }
            }
            // adding rooms to all coworkings
            for (int j = 1; j <= 5; j++)
            {
                rooms.Add(new Room { Id = i++, RoomCapacityId = 4, RoomTypeId = 3, CoworkingId = j });
                rooms.Add(new Room { Id = i++, RoomCapacityId = 5, RoomTypeId = 3, CoworkingId = j });
                rooms.Add(new Room { Id = i++, RoomCapacityId = 5, RoomTypeId = 3, CoworkingId = j });
                // skip private rooms for coworking 4
                if (j == 4)
                {
                    continue;
                }
                rooms.Add(new Room { Id = i++, RoomCapacityId = 1, RoomTypeId = 2, CoworkingId = j });
                rooms.Add(new Room { Id = i++, RoomCapacityId = 2, RoomTypeId = 2, CoworkingId = j });
                rooms.Add(new Room { Id = i++, RoomCapacityId = 3, RoomTypeId = 2, CoworkingId = j });
                rooms.Add(new Room { Id = i++, RoomCapacityId = 4, RoomTypeId = 2, CoworkingId = j });
                rooms.Add(new Room { Id = i++, RoomCapacityId = 1, RoomTypeId = 2, CoworkingId = j });
                rooms.Add(new Room { Id = i++, RoomCapacityId = 2, RoomTypeId = 2, CoworkingId = j });
                rooms.Add(new Room { Id = i++, RoomCapacityId = 3, RoomTypeId = 2, CoworkingId = j });
                rooms.Add(new Room { Id = i++, RoomCapacityId = 1, RoomTypeId = 2, CoworkingId = j });
                rooms.Add(new Room { Id = i++, RoomCapacityId = 2, RoomTypeId = 2, CoworkingId = j });
            }
            // adding unqiue rooms to coworkings
            rooms.Add(new Room { Id = i++, RoomCapacityId = 1, RoomTypeId = 2, CoworkingId = 1 });
            rooms.Add(new Room { Id = i++, RoomCapacityId = 4, RoomTypeId = 3, CoworkingId = 2 });
            rooms.Add(new Room { Id = i++, RoomCapacityId = 3, RoomTypeId = 2, CoworkingId = 3 });
            rooms.Add(new Room { Id = i++, RoomCapacityId = 5, RoomTypeId = 3, CoworkingId = 4 });
            rooms.Add(new Room { Id = i++, RoomCapacityId = 2, RoomTypeId = 2, CoworkingId = 5 });
            rooms.Add(new Room { Id = i++, RoomCapacityId = 2, RoomTypeId = 2, CoworkingId = 1 });
            rooms.Add(new Room { Id = i++, RoomCapacityId = 3, RoomTypeId = 2, CoworkingId = 1 });
            rooms.Add(new Room { Id = i++, RoomCapacityId = 5, RoomTypeId = 3, CoworkingId = 2 });
            rooms.Add(new Room { Id = i++, RoomCapacityId = 4, RoomTypeId = 3, CoworkingId = 2 });
            rooms.Add(new Room { Id = i++, RoomCapacityId = 1, RoomTypeId = 2, CoworkingId = 3 });
            rooms.Add(new Room { Id = i++, RoomCapacityId = 4, RoomTypeId = 2, CoworkingId = 3 });
            rooms.Add(new Room { Id = i++, RoomCapacityId = 5, RoomTypeId = 3, CoworkingId = 4 });
            rooms.Add(new Room { Id = i++, RoomCapacityId = 4, RoomTypeId = 3, CoworkingId = 4 });
            rooms.Add(new Room { Id = i++, RoomCapacityId = 2, RoomTypeId = 2, CoworkingId = 5 });
            rooms.Add(new Room { Id = i++, RoomCapacityId = 3, RoomTypeId = 2, CoworkingId = 5 });

            modelBuilder.Entity<Room>().HasData(rooms);
        }
    }
}
