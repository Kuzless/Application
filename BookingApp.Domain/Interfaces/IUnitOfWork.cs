namespace BookingApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
        IBookingRepository BookingRepository { get; }
    }
}
