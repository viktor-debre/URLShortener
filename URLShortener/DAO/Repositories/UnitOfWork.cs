using Microsoft.EntityFrameworkCore;
using URLShortener.DAO.Interfaces;

namespace URLShortener.DAO.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public IUserRepository Users { get; }
        public IURLRepository URLs { get; }

        public UnitOfWork(ApplicationContext context, IUserRepository userRepository, IURLRepository urlRepository)
        {
            _context = context;
            Users = userRepository;
            URLs = urlRepository;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async void Dispose()
        {
            await Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual async Task Dispose(bool disposing)
        {
            if (disposing)
            {
                await _context.DisposeAsync();
            }
        }
    }
}
