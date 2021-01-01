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
        //private readonly ClientCredentialsTokenRequest _tokenRequest;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public BookApiService(IHttpClientFactory httpClientFactory/*, ClientCredentialsTokenRequest tokenRequest, IHttpContextAccessor httpContextAccessor*/)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            //_tokenRequest = tokenRequest ?? throw new ArgumentNullException(nameof(tokenRequest));
            //_httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        [Authorize(Roles = "Administrator")]
        public async Task CreateBook(BookModel book)
        {
            //var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            var httpClient = _httpClientFactory.CreateClient("AuthenticatedOcelotAPIGateway");

            var stringContent = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "/Books")
            {
                Content = stringContent
            };

            /*if (!string.IsNullOrWhiteSpace(accessToken))
            {
                request.SetBearerToken(accessToken);
            }*/

            var response = await httpClient.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead
                ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        [Authorize(Roles = "Administrator")]
        public async Task DeleteBook(string id)
        {
            //var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            var httpClient = _httpClientFactory.CreateClient("AuthenticatedOcelotAPIGateway");

            var request = new HttpRequestMessage(HttpMethod.Delete, $"/Books/{id}");

            /*if (!string.IsNullOrWhiteSpace(accessToken))
            {
                request.SetBearerToken(accessToken);
            }*/

            var response = await httpClient.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead
                ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<BookModel>> GetBooks()
        {
            //var idpClient = _httpClientFactory.CreateClient("AuthenticatedIDPClient");

            //var tokenResponse = await idpClient.RequestClientCredentialsTokenAsync(_tokenRequest);
            /*if (tokenResponse.IsError)
            {
                throw new HttpRequestException("Something went wrong while requesting the access token");
            }*/

            var httpClient = _httpClientFactory.CreateClient("DefaultOcelotAPIGateway");

            var request = new HttpRequestMessage(HttpMethod.Get, "/Books");

            //request.SetBearerToken(tokenResponse.AccessToken);

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
            //var idpClient = _httpClientFactory.CreateClient("AuthenticatedIDPClient");

            //var tokenResponse = await idpClient.RequestClientCredentialsTokenAsync(_tokenRequest);
            /*if (tokenResponse.IsError)
            {
                throw new HttpRequestException("Something went wrong while requesting the access token");
            }*/

            var httpClient = _httpClientFactory.CreateClient("DefaultOcelotAPIGateway");

            var request = new HttpRequestMessage(HttpMethod.Get, $"/Books/{id}");

            //request.SetBearerToken(tokenResponse.AccessToken);

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
            //var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            var httpClient = _httpClientFactory.CreateClient("AuthenticatedOcelotAPIGateway");

            var stringContent = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Put, $"/Books/{book.id}")
            {
                Content = stringContent
            };

            /*if (!string.IsNullOrWhiteSpace(accessToken))
            {
                request.SetBearerToken(accessToken);
            }*/

            var response = await httpClient.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead
                ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }
    }
}
