namespace BookingApp.Domain.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById<TKey>(TKey id);
    }
}
