using URLShortener.Models.Entities;

namespace URLShortener.DAO.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();

        Task Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
