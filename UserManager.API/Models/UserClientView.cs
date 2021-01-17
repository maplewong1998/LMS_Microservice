using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManager.API.Models
{
    public class UserClientView
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string full_name { get; set; }
        public string dob { get; set; }
        public string address { get; set; }
        public string account_status { get; set; }
        public string password { get; set; }
    }
}
