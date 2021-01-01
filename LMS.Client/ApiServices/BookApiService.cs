using IdentityModel.Client;
using LMS.Client.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Client.ApiServices
{
    public class BookApiService : IBookApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        [Authorize(Roles = "Administrator")]
        public async Task CreateBook(BookModel book)
        {
            var httpClient = _httpClientFactory.CreateClient("AuthenticatedOcelotAPIGateway");

            var stringContent = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "/Books")
            {
                Content = stringContent
            };

            var response = await httpClient.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead
                ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        [Authorize(Roles = "Administrator")]
        public async Task DeleteBook(string id)
        {
            var httpClient = _httpClientFactory.CreateClient("AuthenticatedOcelotAPIGateway");

            var request = new HttpRequestMessage(HttpMethod.Delete, $"/Books/{id}");

            var response = await httpClient.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead
                ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<BookModel>> GetBooks()
        {
            var httpClient = _httpClientFactory.CreateClient("DefaultOcelotAPIGateway");

            var request = new HttpRequestMessage(HttpMethod.Get, "/Books");

            var response = await httpClient.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead
                ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            List<BookModel> bookLists = JsonConvert.DeserializeObject<List<BookModel>>(content);

            return bookLists;
        }

        public async Task<BookModel> GetBook(string id)
        {
            var httpClient = _httpClientFactory.CreateClient("DefaultOcelotAPIGateway");

            var request = new HttpRequestMessage(HttpMethod.Get, $"/Books/{id}");

            var response = await httpClient.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead
                ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            BookModel book = JsonConvert.DeserializeObject<BookModel>(content);

            return book;
        }

        [Authorize(Roles = "Administrator")]
        public async Task UpdateBook(BookModel book)
        {
            var httpClient = _httpClientFactory.CreateClient("AuthenticatedOcelotAPIGateway");

            var stringContent = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Put, $"/Books/{book.id}")
            {
                Content = stringContent
            };

            var response = await httpClient.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead
                ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }
    }
}
