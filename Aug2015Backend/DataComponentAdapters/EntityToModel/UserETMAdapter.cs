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

namespace Aug2015Backend.DataComponentAdapters.EntityToModel
{
    public class UserETMAdapter
    {
        private UserManager<IdentityUser> _userManager;
        private AuthContext _ctx;
        private DataContext _db;

        public UserETMAdapter()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
            _db = new DataContext();
        }

        private IdentityUser GetUser(string id)
        {
            IdentityUser iUser = _userManager.FindById(id);
            return iUser;
        }

        public UserModel MapData(User u)
        {
            UserModel um = new UserModel();
            IdentityUser iUser = GetUser(u.AuthUserId);

            um.UserName = iUser.UserName;
            um.RNR = u.RNR;
            um.FirstName = u.FirstName;
            um.LastName = u.LastName;
            um.Street = u.Street;
            um.HouseNr = u.HouseNr;
            um.Bus = u.Bus;
            um.City = u.City;
            um.PostalCode = u.PostalCode;
            um.PhoneNumber = iUser.PhoneNumber;
            um.AuthUserId = iUser.Id;
            um.Id = u.Id;
            um.Roles = iUser.Roles;

            return um;
        }
    }
}