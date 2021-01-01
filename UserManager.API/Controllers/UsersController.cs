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
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var User = await _userManager.FindByIdAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IdentityResult> PutUser(string id, User user)
        {
            var user_check = await _userManager.FindByIdAsync(id);

            if (user_check != null)
            {
                List<Claim> userCheckClaimList = AssembleClaims(user_check.Email, user_check.full_name, user_check.account_status, user_check.Id);
                await _userManager.RemoveClaimsAsync(user_check, userCheckClaimList);
            }

            var result = await _userManager.UpdateAsync(user);
            List<Claim> claimList = AssembleClaims(user.Email, user.full_name, user.account_status, user.Id);
            await _userManager.AddClaimsAsync(user, claimList);

            return result;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IdentityResult> PostUser(User user)
        {
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                List<Claim> claimList = AssembleClaims(user.Email, user.full_name, user.account_status, user.Id);
                await _userManager.AddToRoleAsync(user, "User");
                await _userManager.AddClaimsAsync(user, claimList);
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
                List<Claim> claimList = AssembleClaims(user.Email, user.full_name, user.account_status, user.Id);
                await _userManager.RemoveFromRoleAsync(user, "User");
                await _userManager.RemoveClaimsAsync(user, claimList);
            }

            return result;
        }

        private List<Claim> AssembleClaims(string email, string name, string account_status, string user_id)
        {
            return new List<Claim>
            {
                new Claim(JwtClaimTypes.Email, email),
                new Claim(JwtClaimTypes.Name, name),
                new Claim("account_status", account_status),
                new Claim("userId", user_id)
            };
        }

        private bool UserExists(string id)
        {
            var result = _userManager.FindByIdAsync(id);

            if (result == null)
            {
                return false;
            }

            return true;
        }
    }
}
