using Aug2015Backend.DataBaseContext;
using Aug2015Backend.DataComponentAdapters;
using Aug2015Backend.DataComponentAdapters.ModelToEntity;
using Aug2015Backend.Entities;
using Aug2015Backend.Models;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage PostPicture (PictureModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            _db.Pictures.Add(new PictureMTEAdapter().MapData(model));
            _db.SaveChanges();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
