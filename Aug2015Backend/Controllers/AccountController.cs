﻿using System;
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

             _db.Users.Add(await new UserMTEAdapter().MapData(userModel));
            _db.SaveChanges();

            if (errorResult != null)
            {
                return errorResult;
            }

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

        
        // api/account/user
        
        [System.Web.Http.AcceptVerbs("GET")]
        [AllowAnonymous]
        public UserModel getAccount(int id)
        {
            var userToMap = _db.Users.Find(id);
            return new UserETMAdapter().MapData(userToMap);
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
