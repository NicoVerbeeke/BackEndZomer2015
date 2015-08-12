using Aug2015Backend.DataBaseContext;
using Aug2015Backend.Entities;
using Aug2015Backend.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters.ModelToEntity
{
    public class UserMTEAdapter
    {
        private UserManager<IdentityUser> _userManager;
        private AuthContext _ctx;

        public UserMTEAdapter()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<User> MapData(UserModel um)
        {
            User u = new User();
            var iUser = await getIdentityUser(um.UserName, um.Password);           
           
            u.Id = um.Id;
            u.RNR = um.RNR;
            u.FirstName = um.FirstName;
            u.LastName = um.LastName;
            u.Street = um.Street;
            u.HouseNr = um.HouseNr;
            u.Bus = um.Bus;
            u.City = um.City;
            u.PostalCode = um.PostalCode;
            u.AuthUserId = iUser.Id;
            return u;
        }

        public async Task<IdentityUser> getIdentityUser(String userName, String password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);
            return user;
        }
    }
}