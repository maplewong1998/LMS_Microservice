using LMS.Client.ApiServices;
using LMS.Client.ViewModels;
using LMS.Models;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMS.Client.Controllers
{
    [Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
    public class UserProfileController : Controller
    {
        private readonly IUserApiService _userApiService;

        public UserProfileController(IUserApiService userApiService)
        {
            _userApiService = userApiService ?? throw new ArgumentNullException(nameof(userApiService));
        }

        [HttpPost]
        public async Task<ActionResult> Update(UserProfileViewModel userProfileViewModel)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index(UserProfileViewModel viewModel)
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            string usernameValue = claimsIdentity.FindFirst("username").Value;
            var userProfile = await _userApiService.GetUser(usernameValue);

            viewModel.user = userProfile;

            return View(viewModel);
        }
    }
}
