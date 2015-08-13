using Aug2015Backend.DataBaseContext;
using Aug2015Backend.DataComponentAdapters;
using Aug2015Backend.DataComponentAdapters.ModelToEntity;
using Aug2015Backend.Entities;
using Aug2015Backend.Models;
using Aug2015Backend.Models.ModelHelpers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace Aug2015Backend.Controllers
{
    public class PictureController : ApiController
    {   
        private DataContext _db;

        public PictureController(){
            _db = new DataContext();
        }

        [Route ("api/picture")]
        [Authorize]
        public HttpResponseMessage PostPicture (PictureModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var identity = (ClaimsIdentity)User.Identity;
            var user = _db.Users.Where(u => u.AuthUserId.Equals(identity.GetUserId())).First();
            var subscriptions = _db.Subscriptions.Where(s => s.UserId == user.Id);

            var allowUpload = false;
            foreach (Subscription s in subscriptions)
            {
                if (s.VacationId == model.VacId)
                {
                    allowUpload = true;
                }
            }
            if (allowUpload)
            {                
                _db.Pictures.Add(new PictureMTEAdapter().MapData(model));
                _db.SaveChanges();
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
            }
            return response;
        }
    }
}
