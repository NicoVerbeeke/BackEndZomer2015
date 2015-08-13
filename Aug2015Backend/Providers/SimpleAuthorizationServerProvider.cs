using Aug2015Backend.DataBaseContext;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Aug2015Backend
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
           
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            AuthContext _auth = new AuthContext();
            UserManager<IdentityUser> _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_auth));
            RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_auth));

            AuthRepository _repo = new AuthRepository();
                IdentityUser user = await _repo.FindUser(context.UserName, context.Password);
                
                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }


                var userIdentity = await _userManager.CreateIdentityAsync(user, context.Options.AuthenticationType);

                foreach (IdentityUserRole role in user.Roles)
                {
                    var iRole = _roleManager.FindById(role.RoleId);
                    userIdentity.AddClaim(new Claim(ClaimTypes.Role, iRole.Name));
                }
            
            userIdentity.AddClaim(new Claim("sub", context.UserName));
            userIdentity.AddClaim(new Claim("role", "user"));

            var ticket = new AuthenticationTicket(userIdentity, null);


            context.Validated(ticket);

        }
    }
}