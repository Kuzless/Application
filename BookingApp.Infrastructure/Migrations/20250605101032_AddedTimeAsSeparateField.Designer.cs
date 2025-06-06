﻿// <auto-generated />
using System;
using BookingApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingApp.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20250605101032_AddedTimeAsSeparateField")]
    partial class AddedTimeAsSeparateField
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookingApp.Domain.Entities.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AC"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Wi-fi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Gaming Console"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Coffee"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Audio Station"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Karaoke"
                        });
                });

            modelBuilder.Entity("BookingApp.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BookingApp.Domain.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("RoomCapacityId")
                        .HasColumnType("int");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomCapacityId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            RoomTypeId = 1
                        },
                        new
                        {
                            Id = 4,
                            RoomCapacityId = 1,
                            RoomTypeId = 3
                        },
                        new
                        {
                            Id = 5,
                            RoomCapacityId = 5,
                            RoomTypeId = 3
                        },
                        new
                        {
                            Id = 6,
                            RoomCapacityId = 5,
                            RoomTypeId = 3
                        },
                        new
                        {
                            Id = 7,
                            RoomCapacityId = 1,
                            RoomTypeId = 2
                        },
                        new
                        {
                            Id = 8,
                            RoomCapacityId = 2,
                            RoomTypeId = 2
                        },
                        new
                        {
                            Id = 9,
                            RoomCapacityId = 3,
                            RoomTypeId = 2
                        },
                        new
                        {
                            Id = 10,
                            RoomCapacityId = 4,
                            RoomTypeId = 2
                        },
                        new
                        {
                            Id = 11,
                            RoomCapacityId = 1,
                            RoomTypeId = 2
                        },
                        new
                        {
                            Id = 12,
                            RoomCapacityId = 2,
                            RoomTypeId = 2
                        },
                        new
                        {
                            Id = 13,
                            RoomCapacityId = 3,
                            RoomTypeId = 2
                        },
                        new
                        {
                            Id = 14,
                            RoomCapacityId = 1,
                            RoomTypeId = 2
                        },
                        new
                        {
                            Id = 15,
                            RoomCapacityId = 2,
                            RoomTypeId = 2
                        });
                });

            modelBuilder.Entity("BookingApp.Domain.Entities.RoomCapacity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Capacity")
                        .IsUnique();

                    b.ToTable("RoomCapacities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 1
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 2
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 5
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 10
                        },
                        new
                        {
                            Id = 5,
                            Capacity = 20
                        });
                });

            modelBuilder.Entity("BookingApp.Domain.Entities.RoomCapacityRoomType", b =>
                {
                    b.Property<int>("RoomCapacityId")
                        .HasColumnType("int");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.HasKey("RoomCapacityId", "RoomTypeId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("RoomCapacityRoomTypes");

                    b.HasData(
                        new
                        {
                            RoomCapacityId = 1,
                            RoomTypeId = 2
                        },
                        new
                        {
                            RoomCapacityId = 2,
                            RoomTypeId = 2
                        },
                        new
                        {
                            RoomCapacityId = 3,
                            RoomTypeId = 2
                        },
                        new
                        {
                            RoomCapacityId = 4,
                            RoomTypeId = 2
                        },
                        new
                        {
                            RoomCapacityId = 4,
                            RoomTypeId = 3
                        },
                        new
                        {
                            RoomCapacityId = 5,
                            RoomTypeId = 3
                        });
                });

            modelBuilder.Entity("BookingApp.Domain.Entities.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("RoomTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A vibrant shared area perfect for freelancers or small teams who enjoy a collaborative atmosphere. Choose any available desk and get to work with flexibility and ease.",
                            Type = "Open Space"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Designed for productive meetings, workshops, or client presentations. Equipped with screens, whiteboards, and comfortable seating to keep your sessions running smoothly.",
                            Type = "Private Rooms"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Ideal for focused work, video calls, or small team huddles. These fully enclosed rooms offer privacy and come in a variety of sizes to fit your needs.",
                            Type = "Meeting Rooms"
                        });
                });

            modelBuilder.Entity("BookingApp.Domain.Entities.RoomTypeAmenity", b =>
                {
                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.HasKey("RoomTypeId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("RoomTypeAmenties");

                    b.HasData(
                        new
                        {
                            RoomTypeId = 1,
                            AmenityId = 1
                        },
                        new
                        {
                            RoomTypeId = 1,
                            AmenityId = 2
                        },
                        new
                        {
                            RoomTypeId = 1,
                            AmenityId = 3
                        },
                        new
                        {
                            RoomTypeId = 1,
                            AmenityId = 4
                        },
                        new
                        {
                            RoomTypeId = 2,
                            AmenityId = 1
                        },
                        new
                        {
                            RoomTypeId = 2,
                            AmenityId = 2
                        },
                        new
                        {
                            RoomTypeId = 2,
                            AmenityId = 5
                        },
                        new
                        {
                            RoomTypeId = 3,
                            AmenityId = 1
                        },
                        new
                        {
                            RoomTypeId = 3,
                            AmenityId = 2
                        },
                        new
                        {
                            RoomTypeId = 3,
                            AmenityId = 5
                        },
                        new
                        {
                            RoomTypeId = 3,
                            AmenityId = 6
                        });
                });

            modelBuilder.Entity("BookingApp.Domain.Entities.Booking", b =>
                {
                    b.HasOne("BookingApp.Domain.Entities.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("BookingApp.Domain.Entities.Room", b =>
                {
                    b.HasOne("BookingApp.Domain.Entities.RoomCapacity", "RoomCapacity")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomCapacityId");

                    b.HasOne("BookingApp.Domain.Entities.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomCapacity");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("BookingApp.Domain.Entities.RoomCapacityRoomType", b =>
                {
                    b.HasOne("BookingApp.Domain.Entities.RoomCapacity", "RoomCapacity")
                        .WithMany("RoomTypes")
                        .HasForeignKey("RoomCapacityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingApp.Domain.Entities.RoomType", "RoomType")
                        .WithMany("RoomCapacities")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomCapacity");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("BookingApp.Domain.Entities.RoomTypeAmenity", b =>
                {
                    b.HasOne("BookingApp.Domain.Entities.Amenity", "Amenity")
                        .WithMany("RoomTypeAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingApp.Domain.Entities.RoomType", "RoomType")
                        .WithMany("RoomTypeAmenities")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("BookingApp.Domain.Entities.Amenity", b =>
                {
                    b.Navigation("RoomTypeAmenities");
                });

            modelBuilder.Entity("BookingApp.Domain.Entities.Room", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BookingApp.Domain.Entities.RoomCapacity", b =>
                {
                    b.Navigation("RoomTypes");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("BookingApp.Domain.Entities.RoomType", b =>
                {
                    b.Navigation("RoomCapacities");

                    b.Navigation("RoomTypeAmenities");

                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
