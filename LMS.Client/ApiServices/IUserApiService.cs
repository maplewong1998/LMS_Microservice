using LMS.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Client.ApiServices
{
    public interface IUserApiService
    {
        Task<IEnumerable<AppUserModel>> GetUsers();
        Task<AppUserModel> GetUser(string id);
        Task CreateUser(AppUserModel user);
        Task UpdateUser(AppUserModel user);
        Task DeleteUser(string id);
    }
}
