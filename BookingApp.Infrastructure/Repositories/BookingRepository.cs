using BookingApp.Domain.Entities;
using BookingApp.Domain.Interfaces;

namespace BookingApp.Infrastructure.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
