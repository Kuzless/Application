using BookingApp.Domain.Interfaces;
using BookingApp.Infrastructure.Repositories;

namespace BookingApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public ICoworkingRepository CoworkingRepository { get; set; }
        public IRoomTypeRepository RoomTypeRepository { get; }
        public IBookingRepository BookingRepository { get; }
        public IRoomRepository RoomRepository { get; }
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            BookingRepository = new BookingRepository(_context);
            RoomTypeRepository = new RoomTypeRepository(_context);
            RoomRepository = new RoomRepository(_context);
            CoworkingRepository = new CoworkingRepository(_context);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
