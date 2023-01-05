using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using URLShortener.Models;
using URLShortener.Models.ViewModels;
using URLShortener.Services.Interfaces;

namespace URLShortener.Controllers
{
    public class HomeController : Controller
    {
        private readonly IURLService _urlService;

        public HomeController(IURLService urlService)
        {
            _urlService = urlService;
        }

        public async Task<IActionResult> Index()
        {
            var urls = await _urlService.GetAllURLs();
            return View(urls);
        }

        [Authorize]
        public async Task<IActionResult> DeleteUrl(int id)
        {
            var result = await _urlService.DeleteURL(id);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        public IActionResult AddUrl()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> AddNewUrl(UrlView urlView)
        {
            var result = await _urlService.AddURL(urlView.FullUrl, User.Identity.Name);

            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> ShortURLInfo(int id)
        {
            var url = await _urlService.GetURLById(id);
            return View(url);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}