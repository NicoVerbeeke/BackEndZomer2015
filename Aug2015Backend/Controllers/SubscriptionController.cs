using Aug2015Backend.DataBaseContext;
using Aug2015Backend.DataComponentAdapters;
using Aug2015Backend.DataComponentAdapters.EntityToModel;
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
    
    public class SubscriptionController : ApiController
    {   
        private DataContext _db;

        public SubscriptionController(){           
            _db = new DataContext();
        }


        //GET -> api/Account/Subs/{id}
        //gets all subscriptions for the given userid
        [AcceptVerbs("GET")]
        public List<SubscriptionModel> GetSubscription(int id)
        {
            List<Subscription> subs = new List<Subscription>();
            subs = _db.Subscriptions.Where(s => s.VacationId == id).ToList();

            
            List<SubscriptionModel> subModels = new List<SubscriptionModel>();
            SubscriptionETMAdapter subAdapter = new SubscriptionETMAdapter();
            foreach (Subscription sub in subs)
            {
                subModels.Add(subAdapter.MapData(sub));
            }
            return subModels;
        }

        // POST -> api/Subscribe 
        // Expects a SubscriptionModel in its body, for more details have a look at SubscriptionModel.js
        [Route("api/Subscribe")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage PostSubscribe(SubscriptionModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            if (!ModelState.IsValid)
            {
                var b = BadRequest(ModelState);

            }

            int VacId = model.VacId;
            int UserId = model.UserId;
            

            Vacation wantedVacation = _db.Vacations.Find(VacId);
            int subscriptionsAmount = _db.Subscriptions.Where(s => s.VacationId == VacId).Count();
            if ((wantedVacation.NumberOfParticipants - subscriptionsAmount) > 1)
            {
                List<Subscription> subscriptions = _db.Subscriptions.Where(s => s.UserId == UserId).ToList();
                if (subscriptions.Count > 0)
                {
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
                                _db.Subscriptions.Add(new SubscriptionMTEAdapter().MapData(model));
                                _db.SaveChanges();                            
                                response.StatusCode = HttpStatusCode.OK;
                            }
                        
                    }
                }
                else
                {
                    _db.Subscriptions.Add(new SubscriptionMTEAdapter().MapData(model));   
                    try
                    {
                        _db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        var b = true;
                    }

                    response.StatusCode = HttpStatusCode.OK;
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
