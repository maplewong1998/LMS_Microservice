using LMS.Client.ViewModels;
using LMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Client.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MemberManagementController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(MemberManagementViewModel memberManagementViewModel)
        {
            return View();
        }
    }
}
