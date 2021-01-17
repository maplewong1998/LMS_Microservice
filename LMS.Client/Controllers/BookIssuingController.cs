using LMS.Client.Models;
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
    public class BookIssuingController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(BookIssueModel bookIssueModel)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return View();
        }
    }
}
