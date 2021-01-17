using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using UserManager.API.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using IdentityModel;

namespace UserManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize("ClientIdPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserClientView>>> GetUsers()
        {
            List<UserClientView> userListClientView = new List<UserClientView>();
            List<User> userListDb = await _userManager.Users.ToListAsync();
            foreach (User user in userListDb)
            {
                UserClientView userClientView = new UserClientView
                {
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    UserName = user.UserName,
                    full_name = user.full_name,
                    dob = user.dob,
                    address = user.address,
                    account_status = user.account_status,
                    password = null
                };
                userListClientView.Add(userClientView);
            }
            return userListClientView;
        }

        // GET: api/Users/5
        [HttpGet("{username}")]
        public async Task<ActionResult<UserClientView>> GetUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            UserClientView userClientView = new UserClientView
            {
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                UserName = user.UserName,
                full_name = user.full_name,
                dob = user.dob,
                address = user.address,
                account_status = user.account_status,
                password = null
            };

            return userClientView;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{username}")]
        public async Task<IdentityResult> PutUser(string username, UserClientView userClientView)
        {
            User user_check = await _userManager.FindByNameAsync(username);

            var passwordValidateResult = await _userManager.CheckPasswordAsync(user_check, userClientView.password);

            if (passwordValidateResult)
            {
                List<Claim> userCheckClaimList = AssembleClaims(user_check.Email, user_check.full_name, user_check.account_status);
                await _userManager.RemoveClaimsAsync(user_check, userCheckClaimList);
            }
            else
            {
                return IdentityResult.Failed();
            }

            User updatedUser = new User
            {
                LockoutEnd = user_check.LockoutEnd,
                TwoFactorEnabled = user_check.TwoFactorEnabled,
                PhoneNumberConfirmed = user_check.PhoneNumberConfirmed,
                PhoneNumber = userClientView.PhoneNumber,//updated
                ConcurrencyStamp = user_check.ConcurrencyStamp,
                SecurityStamp = user_check.SecurityStamp,
                PasswordHash = user_check.PasswordHash,
                EmailConfirmed = user_check.EmailConfirmed,
                NormalizedEmail = userClientView.Email.ToUpper(),//updated
                Email = userClientView.Email,
                NormalizedUserName = userClientView.UserName.ToUpper(),//updated
                UserName = userClientView.UserName,//updated
                Id = user_check.Id,
                LockoutEnabled = user_check.LockoutEnabled,
                AccessFailedCount = user_check.AccessFailedCount,
                full_name = userClientView.full_name,//updated
                dob = userClientView.dob,//updated
                address = userClientView.address,//updated
                account_status = userClientView.account_status//updated
            };

            var result = await _userManager.UpdateAsync(updatedUser);
            List<Claim> claimList = AssembleClaims(updatedUser.Email, updatedUser.full_name, updatedUser.account_status);
            await _userManager.AddClaimsAsync(updatedUser, claimList);

            return result;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IdentityResult> PostUser(UserClientView userClientView)
        {
            User userCreated = new User 
            {
                PhoneNumber = userClientView.PhoneNumber,
                Email = userClientView.Email,
                UserName = userClientView.UserName,
                full_name = userClientView.full_name,
                dob = userClientView.dob,
                address = userClientView.address,
                account_status = userClientView.account_status,
            };

            var result = await _userManager.CreateAsync(userCreated, userClientView.password);

            if (result.Succeeded)
            {
                List<Claim> claimList = AssembleClaims(userClientView.Email, userClientView.full_name, userClientView.account_status);
                await _userManager.AddToRoleAsync(userCreated, "User");
                await _userManager.AddClaimsAsync(userCreated, claimList);
            }

            return result;
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IdentityResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userRole = await _userManager.GetRolesAsync(user);

            if (user == null || userRole[0] == "Administrator")
            {
                return IdentityResult.Failed();
            }

            var result = await _userManager.DeleteAsync(user);
            
            if (result.Succeeded)
            {
                List<Claim> claimList = AssembleClaims(user.Email, user.full_name, user.account_status);
                await _userManager.RemoveFromRoleAsync(user, "User");
                await _userManager.RemoveClaimsAsync(user, claimList);
            }

            return result;
        }

        private List<Claim> AssembleClaims(string email, string name, string account_status)
        {
            return new List<Claim>
            {
                new Claim(JwtClaimTypes.Email, email),
                new Claim(JwtClaimTypes.Name, name),
                new Claim("account_status", account_status),
            };
        }

        private bool UserExists(string username)
        {
            var result = _userManager.FindByNameAsync(username);

            if (result == null)
            {
                return false;
            }

            return true;
        }
    }
}
