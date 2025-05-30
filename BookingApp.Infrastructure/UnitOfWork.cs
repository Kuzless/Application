﻿using BookingApp.Domain.Interfaces;
using BookingApp.Infrastructure.Repositories;

namespace BookingApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public IRoomTypeRepository RoomTypeRepository { get; }
        public IBookingRepository BookingRepository { get; }
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            BookingRepository = new BookingRepository(_context);
            RoomTypeRepository = new RoomTypeRepository(_context);
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
