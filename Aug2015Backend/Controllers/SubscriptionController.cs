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
    [RoutePrefix("api/Subscribe")]
    public class SubscriptionController : ApiController
    {   
        private DataContext _db;

        public SubscriptionController(){           
            _db = new DataContext();
        }

        public HttpResponseMessage Subscribe(int VacId, int UserId)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            Vacation wantedVacation = _db.Vacations.Find(VacId);
            int subscriptionsAmount = _db.Subscriptions.Where(s => s.VacationId == VacId).Count();
            if ((wantedVacation.NumberOfParticipants - subscriptionsAmount) > 1)
            {
                List<Subscription> subscriptions = _db.Subscriptions.Where(s => s.UserId == UserId).ToList();
                if (subscriptions.Count > 0)
                {
                    Boolean noOverlap = true;
                    foreach (Subscription s in subscriptions)
                    {
                        Vacation ListedVacation = _db.Vacations.Find(s.VacationId);
                        List<Period> periods = ListedVacation.When.ToList();
                        foreach (Period p in periods)
                        {
                           // if()
                        }
                    }
                }

                SubscriptionModel sm = new SubscriptionModel();
                sm.VacId = VacId;
                
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotAcceptable;
            }


            return response;
        }
    }
}
