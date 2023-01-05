using URLShortener.Models.Entities;

namespace URLShortener.Services.Interfaces
{
    public interface IURLService
    {
        public Task<bool> AddURL(URL url);

        public Task<bool> DeleteURL(int urlId);

        public Task<IEnumerable<URL>> GetAllURLs();

        public Task<URL> GetURLById(int urlId);
    }
}
