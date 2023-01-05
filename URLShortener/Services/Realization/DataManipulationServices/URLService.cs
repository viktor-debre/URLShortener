using URLShortener.DAO.Interfaces;
using URLShortener.Models.Entities;
using URLShortener.Services.Interfaces;

namespace URLShortener.Services.Realization
{
    public class URLService : IURLService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShortenerService _shortenerService;

        public URLService(IUnitOfWork unitOfWork, IShortenerService shortenerService)
        {
            _unitOfWork = unitOfWork;
            _shortenerService = shortenerService;
        }

        public async Task<bool> AddURL(string fullUrl, string userName)
        {
            if (fullUrl != null)
            {
                string shortUrl = await _shortenerService.GetShortUrlFromAPI(fullUrl);
                var result = 0;
                if (shortUrl != "")
                {
                    var url = new URL() 
                    { 
                        FullUrl = fullUrl,
                        ShortUrl = shortUrl,
                        CreatedBy = userName,
                        CreatedDate = DateTime.Now
                    };
                    await _unitOfWork.URLs.Add(url);
                    result = _unitOfWork.Save();
                }

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public async Task<bool> DeleteURL(int urlId)
        {
            if (urlId > 0)
            {
                var productDetails = await _unitOfWork.URLs.GetById(urlId);
                if (productDetails != null)
                {
                    _unitOfWork.URLs.Delete(productDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public async Task<IEnumerable<URL>> GetAllURLs()
        {
            var productDetailsList = await _unitOfWork.URLs.GetAll();
            return productDetailsList;
        }

        public async Task<URL?> GetURLById(int urlId)
        {
            if (urlId > 0)
            {
                var productDetails = await _unitOfWork.URLs.GetById(urlId);
                if (productDetails != null)
                {
                    return productDetails;
                }
            }
            return null;
        }
    }
}