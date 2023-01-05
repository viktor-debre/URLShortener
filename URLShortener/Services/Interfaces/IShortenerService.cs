namespace URLShortener.Services.Interfaces
{
    public interface IShortenerService
    {
        public Task<string> GetShortUrlFromAPI(string url);
    }
}
