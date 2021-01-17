using LMS.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Client.ApiServices
{
    public interface IUserApiService
    {
        Task<IEnumerable<AppUserClientViewModel>> GetUsers();
        Task<AppUserClientViewModel> GetUser(string username);
        Task CreateUser(AppUserClientViewModel user);
        Task UpdateUser(AppUserClientViewModel user);
        Task DeleteUser(string username);
    }
}
