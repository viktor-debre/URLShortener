using URLShortener.DAO.Interfaces;
using URLShortener.Models.Entities;
using URLShortener.Services.Interfaces;

namespace URLShortener.Services.Realization
{
    public class URLService : IURLService
    {
        private readonly IUnitOfWork _unitOfWork;

        public URLService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddURL(URL url)
        {
            if (url != null)
            {
                await _unitOfWork.URLs.Add(url);

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

        public async Task<URL> GetURLById(int urlId)
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
