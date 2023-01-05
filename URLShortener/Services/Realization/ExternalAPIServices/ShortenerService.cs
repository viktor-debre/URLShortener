using URLShortener.Services.Interfaces;

namespace URLShortener.Services.Realization
{
    public class ShortenerService : IShortenerService
    {
        private readonly HttpClient _httpClient;
        private const string externalAPIPath = "https://is.gd/create.php?format=simple&url=";

        public ShortenerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetShortUrlFromAPI(string url)
        {
            var path = externalAPIPath + url;
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            string shortUrl = "";
            if (response.IsSuccessStatusCode)
            {
                shortUrl = await response.Content.ReadAsStringAsync();
            }

            return shortUrl;
        }
    }
}
