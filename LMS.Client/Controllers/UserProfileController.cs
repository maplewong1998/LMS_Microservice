using LMS.Client.ViewModels;
using LMS.Models;
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
    public class UserProfileController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Edit(UserProfileViewModel userProfileViewModel)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
