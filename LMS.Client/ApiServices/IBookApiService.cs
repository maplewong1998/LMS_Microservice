using LMS.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Client.ApiServices
{
    public interface IBookApiService
    {
        Task<IEnumerable<BookModel>> GetBooks();
        Task<BookModel> GetBook(string id);
        Task CreateBook(BookModel book);
        Task UpdateBook(BookModel book);
        Task DeleteBook(string id);
    }
}
