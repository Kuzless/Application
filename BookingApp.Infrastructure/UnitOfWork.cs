using BookingApp.Domain.Interfaces;
using BookingApp.Infrastructure.Repositories;

namespace BookingApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public IBookingRepository BookingRepository { get; }
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            BookingRepository = new BookingRepository(_context);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
