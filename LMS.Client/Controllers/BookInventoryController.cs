using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using LMS.Client.ViewModels;
using LMS.Client.ApiServices;
using LMS.Client.Models;
using Microsoft.AspNetCore.Authorization;

namespace LMS.Client.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BookInventoryController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBookApiService _bookApiService;

        public BookInventoryController(IWebHostEnvironment webHostEnvironment, IBookApiService bookApiService)
        {
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            _bookApiService = bookApiService ?? throw new ArgumentNullException(nameof(bookApiService));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _bookApiService.GetBooks());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookIventoryCE_ViewModel book)
        {
            if (ModelState.IsValid)
            {
                BookModel savebook = new BookModel
                {
                    id = book.id,
                    book_name = book.book_name,
                    genre = book.genre,
                    author_name = book.author_name,
                    publisher_name = book.publisher_name,
                    publish_date = book.publish_date,
                    language = book.language,
                    edition = book.edition,
                    book_cost = book.book_cost,
                    no_of_pages = book.no_of_pages,
                    book_description = book.book_description,
                    actual_stock = book.actual_stock,
                    issued_books = 0,
                    book_img = UploadFile(book.book_pic)
                };
                await _bookApiService.CreateBook(savebook);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookModel book_retrieved = await _bookApiService.GetBook(id);

            if (book_retrieved == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Edit(string id, BookIventoryCE_ViewModel book)
        {
            if (id != book.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                BookModel savebook;
                if (book.book_pic != null)
                {
                    savebook = new BookModel
                    {
                        id = book.id,
                        book_name = book.book_name,
                        genre = book.genre,
                        author_name = book.author_name,
                        publisher_name = book.publisher_name,
                        publish_date = book.publish_date,
                        language = book.language,
                        edition = book.edition,
                        book_cost = book.book_cost,
                        no_of_pages = book.no_of_pages,
                        book_description = book.book_description,
                        actual_stock = book.actual_stock,
                        book_img = UploadFile(book.book_pic)
                    };
                }
                else
                {
                    savebook = new BookModel
                    {
                        id = book.id,
                        book_name = book.book_name,
                        genre = book.genre,
                        author_name = book.author_name,
                        publisher_name = book.publisher_name,
                        publish_date = book.publish_date,
                        language = book.language,
                        edition = book.edition,
                        book_cost = book.book_cost,
                        no_of_pages = book.no_of_pages,
                        book_description = book.book_description,
                        actual_stock = book.actual_stock,
                    };
                }

                await _bookApiService.UpdateBook(savebook);
                
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        private string UploadFile(IFormFile ifile)
        {
            string img_name = null;            
            if (ifile != null)
            {
                string imgext = Path.GetExtension(ifile.FileName);
                if (imgext == ".jpg" || imgext == ".gif")
                {
                    string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "lib/resources/books");
                    img_name = Guid.NewGuid().ToString() + "_" + ifile.FileName;
                    string filePath = Path.Combine(uploadFolder, img_name);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        ifile.CopyTo(fileStream);
                    }
                }
            }
            return img_name;
        }
    }
}
