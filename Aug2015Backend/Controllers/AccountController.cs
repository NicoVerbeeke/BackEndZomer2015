using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.Owin.Security;
using Aug2015Backend.Models;
using Microsoft.AspNet.Identity;
using Aug2015Backend.DataBaseContext;
using Aug2015Backend.DataComponentAdapters.ModelToEntity;
using Aug2015Backend.DataComponentAdapters;
using Aug2015Backend.DataComponentAdapters.EntityToModel;
using Aug2015Backend.Models.ModelHelpers;
using Aug2015Backend.Entities;
using System.Linq;
using System.Net;

namespace Aug2015Backend.Controllers
{
    
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;
        private DataContext _db = null;

        public AccountController()
        {
            _repo = new AuthRepository();
            _db = new DataContext();
        }        

        // POST api/Account/Register
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {         
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);             

            if (errorResult != null)
            {
                return errorResult;
            }
            _db.Users.Add(await new UserMTEAdapter().MapData(userModel));

            _db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        [Authorize]
        public UserModel getAccounts([FromUri] string username)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userModel = new UserModel();
            if (identity.GetUserId().Equals(_repo.FindByEmail(username).Id))
            {
                //In our application the username of a user is his/her email adres.
                var iUser = _repo.FindByEmail(username);
                var userToMap = _db.Users.Where(u => u.AuthUserId.Equals(iUser.Id)).Single();
                userModel = new UserETMAdapter().MapData(userToMap);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            return userModel;
        }

        // api/account/{userId}     
        [AcceptVerbs("GET")]
        [Authorize(Roles = "Admin")]
        public UserModel getAccounts([FromUri] string username, [FromUri]string role)
        {
            //In our application the username of a user is his/her email adres.
            var iUser = _repo.FindByEmail(username);
            var userToMap = _db.Users.Where(u => u.AuthUserId.Equals(iUser.Id)).Single();
            return new UserETMAdapter().MapData(userToMap);
        }

        // api/account/user

        [System.Web.Http.AcceptVerbs("GET")]
        [AllowAnonymous]
        public HttpResponseMessage getAccount()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<object>(new
                {
                    UserName = User.Identity.GetUserName()
                }, Configuration.Formatters.JsonFormatter)
            };

        }


        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
