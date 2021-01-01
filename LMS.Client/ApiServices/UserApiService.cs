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
        private readonly ClientCredentialsTokenRequest _tokenRequest;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserApiService(IHttpClientFactory httpClientFactory, ClientCredentialsTokenRequest tokenRequest, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _tokenRequest = tokenRequest ?? throw new ArgumentNullException(nameof(tokenRequest));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task CreateUser(AppUserModel user)
        {
            var idpClient = _httpClientFactory.CreateClient("IDPClient");

            var tokenResponse = await idpClient.RequestClientCredentialsTokenAsync(_tokenRequest);
            if (tokenResponse.IsError)
            {
                throw new HttpRequestException("Something went wrong while requesting the access token");
            }

            var httpClient = _httpClientFactory.CreateClient("OcelotAPIGateway");

            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "/Users")
            {
                Content = stringContent
            };

            if (!string.IsNullOrWhiteSpace(tokenResponse.AccessToken))
            {
                request.SetBearerToken(tokenResponse.AccessToken);
            }

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
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            var httpClient = _httpClientFactory.CreateClient("OcelotAPIGateway");

            var request = new HttpRequestMessage(HttpMethod.Get, $"/Users/{id}");

            request.SetBearerToken(accessToken);

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
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            var httpClient = _httpClientFactory.CreateClient("OcelotAPIGateway");

            var request = new HttpRequestMessage(HttpMethod.Get, "/Users");

            request.SetBearerToken(accessToken);

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
