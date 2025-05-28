namespace BookingApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        IBookingRepository BookingRepository { get; }
    }
}
