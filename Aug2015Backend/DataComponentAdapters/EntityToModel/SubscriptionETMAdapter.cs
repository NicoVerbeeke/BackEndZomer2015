using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters.EntityToModel
{
    public class SubscriptionETMAdapter
    {
        public SubscriptionModel MapData(Subscription s){
            SubscriptionModel model = new SubscriptionModel();

            model.Id = s.Id;
            model.UserId = s.UserId;
            model.VacId = s.VacationId;

            return model;
        }
    }
}