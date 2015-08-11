using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters.ModelToEntity
{
    public class SubscriptionETMAdapter
    {
        public Subscription MapData(SubscriptionModel sm)
        {
            Subscription s = new Subscription();

            s.Id = sm.Id;
            s.VacationId = sm.VacId;
            s.UserId = sm.UserId;

            return s;
        }
    }
}