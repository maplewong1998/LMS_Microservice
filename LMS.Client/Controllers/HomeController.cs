using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using LMS.Models;
using Microsoft.AspNetCore.Identity;
using LMS.Client.ViewModels;
using LMS.Client.ApiServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace LMS.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookApiService _bookApiService;

        public HomeController(IBookApiService bookApiService)
        {
            _bookApiService = bookApiService ?? throw new ArgumentNullException(nameof(bookApiService));
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Library()
        {
            return View(await _bookApiService.GetBooks());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Library_Borrow(string id)
        {
            var book_retrieved = await _bookApiService.GetBook(id);
            BookIventoryCE_ViewModel book = new BookIventoryCE_ViewModel
            {
                id = book_retrieved.id,
                book_name = book_retrieved.book_name,
                genre = book_retrieved.genre,
                author_name = book_retrieved.author_name,
                publisher_name = book_retrieved.publisher_name,
                publish_date = book_retrieved.publish_date,
                language = book_retrieved.language,
                edition = book_retrieved.edition,
                book_cost = book_retrieved.book_cost,
                no_of_pages = book_retrieved.no_of_pages,
                book_description = book_retrieved.book_description,
                actual_stock = book_retrieved.actual_stock,
                issued_books = book_retrieved.issued_books,
                book_img = book_retrieved.book_img,
            };
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Library_Borrow(string id, BookIventoryCE_ViewModel book)
        {
            return View();
        }

        //Used for debugging
        public async Task LogTokenAndClaims()
        {
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            Debug.WriteLine($"Identity token: {identityToken}");

            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }
        }
    }
}
