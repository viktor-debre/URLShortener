using URLShortener.Models.Entities;

namespace URLShortener.Services.Interfaces
{
    public interface IURLService
    {
        public Task<bool> AddURL(string fullUrl, string userName);

        public Task<bool> DeleteURL(int urlId);

        public Task<IEnumerable<URL>> GetAllURLs();

        public Task<URL> GetURLById(int urlId);
    }
}
