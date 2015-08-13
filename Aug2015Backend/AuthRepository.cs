using Aug2015Backend.DataBaseContext;
using Aug2015Backend.Models;
using Aug2015Backend.Models.ModelHelpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Aug2015Backend
{
    public class AuthRepository : IDisposable
    {
        private DataContext _db;
        private AuthContext _ctx;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _db = new DataContext();
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName,
                Email = userModel.UserName,
                PhoneNumber = userModel.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            var users = _db.Users.ToList();
            if(!(users.Count > 0)){
                _roleManager.Create(new IdentityRole("Admin"));
                _userManager.AddToRole(user.Id, "Admin");
            }

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<IdentityUser> FindByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }

    }
}