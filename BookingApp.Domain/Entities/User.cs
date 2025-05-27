﻿namespace BookingApp.Domain.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
