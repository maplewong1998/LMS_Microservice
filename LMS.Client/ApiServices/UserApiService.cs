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

        public async Task CreateUser(AppUserModel user)
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
        public Task DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUserModel> GetUser(string id)
        {
            var httpClient = _httpClientFactory.CreateClient("AuthenticatedOcelotAPIGateway");

            var request = new HttpRequestMessage(HttpMethod.Get, $"/Users/{id}");

            var response = await httpClient.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead
                ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            AppUserModel user = JsonConvert.DeserializeObject<AppUserModel>(content);

            return user;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IEnumerable<AppUserModel>> GetUsers()
        {
            var httpClient = _httpClientFactory.CreateClient("AuthenticatedOcelotAPIGateway");

            var request = new HttpRequestMessage(HttpMethod.Get, "/Users");

            var response = await httpClient.SendAsync(
                    request, HttpCompletionOption.ResponseHeadersRead
                ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            List<AppUserModel> userList = JsonConvert.DeserializeObject<List<AppUserModel>>(content);

            return userList;
        }

        public Task UpdateUser(AppUserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
