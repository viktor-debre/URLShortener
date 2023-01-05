using URLShortener.DAO.Interfaces;
using URLShortener.Models.Entities;

namespace URLShortener.DAO.Repositories
{
    public class URLRepository : GenericRepository<URL>, IURLRepository
    {
        public URLRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
