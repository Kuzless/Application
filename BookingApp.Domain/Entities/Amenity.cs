﻿namespace BookingApp.Domain.Entities
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RoomTypeAmenity> RoomTypeAmenities { get; set; }
    }
}
