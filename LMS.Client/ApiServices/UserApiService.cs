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
    public class UserApiService : IUserApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task CreateUser(AppUserClientViewModel user)
        {
            var httpClient = _httpClientFactory.CreateClient("AuthenticatedOcelotAPIGateway");

            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "/Users")
            {
                Content = stringContent
            };

            var response = await httpClient.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead
                ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        [Authorize(Roles = "Administrator")]
        public Task DeleteUser(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUserClientViewModel> GetUser(string username)
        {
            var httpClient = _httpClientFactory.CreateClient("AuthenticatedOcelotAPIGateway");

            var request = new HttpRequestMessage(HttpMethod.Get, $"/Users/{username}");

            var response = await httpClient.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead
                ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            AppUserClientViewModel user = JsonConvert.DeserializeObject<AppUserClientViewModel>(content);

            return user;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IEnumerable<AppUserClientViewModel>> GetUsers()
        {
            var httpClient = _httpClientFactory.CreateClient("AuthenticatedOcelotAPIGateway");

            var request = new HttpRequestMessage(HttpMethod.Get, "/Users");

            var response = await httpClient.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead
                ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            List<AppUserClientViewModel> userList = JsonConvert.DeserializeObject<List<AppUserClientViewModel>>(content);

            return userList;
        }

        public Task UpdateUser(AppUserClientViewModel user)
        {
            throw new NotImplementedException();
        }
    }
}
