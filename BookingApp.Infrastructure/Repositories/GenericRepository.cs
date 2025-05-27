using BookingApp.Domain.Interfaces;

namespace BookingApp.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
    }
}
