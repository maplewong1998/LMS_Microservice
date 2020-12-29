using LMS.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Client.ViewModels
{
    public class MemberManagementViewModel
    {
        public IEnumerable<AppUserModel> user_list { get; set; }
        public AppUserModel user { get; set; }

    }
}
