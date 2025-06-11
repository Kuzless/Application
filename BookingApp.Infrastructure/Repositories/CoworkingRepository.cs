using BookingApp.Domain.Entities;
using BookingApp.Domain.Interfaces;

namespace BookingApp.Infrastructure.Repositories
{
    public class CoworkingRepository : GenericRepository<Coworking>, ICoworkingRepository
    {
        public CoworkingRepository(DatabaseContext context) : base(context)
        {
            
        }
    }
}
