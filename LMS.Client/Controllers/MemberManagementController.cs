using LMS.Client.ViewModels;
using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Client.Controllers
{
    public class MemberManagementController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(MemberManagementViewModel memberManagementViewModel)
        {
            return View();
        }
    }
}
