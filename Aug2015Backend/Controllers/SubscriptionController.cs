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
                        Period period = ListedVacation.When;   
                        //CompareTo:
                        //A signed number indicating the relative values of this instance and the value
                        //parameter.Value Description Less than zero This instance is earlier than
                        //value. Zero This instance is the same as value. Greater than zero This instance
                        //is later than value.

                        //if the starting and ending date of the listed vacation do not lie in between the starting and ending date of the vacation with a pending subscription
                        // wantedVacation.When.DateStart <= period.DateStart <= twantedVacation.When.DateEnd
                        if(!(((period.DateStart.CompareTo(wantedVacation.When.DateEnd) <= 0) && (period.DateStart.CompareTo(wantedVacation.When.DateStart) >= 1))
                            // wantedVacation.When.DateStart <= period.DateEnd <= twantedVacation.When.DateEnd
                            || ((period.DateEnd.CompareTo(wantedVacation.When.DateEnd) <= 0) && (period.DateEnd.CompareTo(wantedVacation.When.DateStart) >= 1))))
                            {
                                
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
