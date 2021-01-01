using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UserManager.API.Models
{
    // Add profile data for application users by adding properties to the AppUserModel class
    public class User : IdentityUser
    {
        [PersonalData]
        public string full_name { get; set; }
        [PersonalData]
        public string dob { get; set; }
        [PersonalData]
        public string address { get; set; }
        [PersonalData]
        public string account_status { get; set; }
    }
}
