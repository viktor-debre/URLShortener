using URLShortener.DAO.Interfaces;
using URLShortener.Models.Entities;

namespace URLShortener.DAO.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context) 
        {
        }
    }
}
