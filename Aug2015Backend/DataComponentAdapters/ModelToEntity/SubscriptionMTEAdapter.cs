using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters.ModelToEntity
{
    public class SubscriptionMTEAdapter
    {
        public Subscription MapData(SubscriptionModel sm)
        {
            Subscription s = new Subscription();

            s.Id = sm.Id;
            s.VacationId = sm.VacId;
            s.UserId = sm.UserId;
            s.FirstName = sm.FirstName;
            s.LastName = sm.LastName;
            s.RNR = sm.RNR;
            s.Street = sm.Street;
            s.HouseNr = sm.HouseNr;
            s.PostalCode = sm.PostalCode;
            s.City = sm.City;
            s.Name_Mother = sm.Name_Mother;
            s.Name_Father = sm.Name_Father;
            s.RNR_Mother = sm.RNR_Mother;
            s.RNR_Father = sm.RNR_Father;
            s.TelephoneNumber = sm.TelephoneNumber;
            s.Email = sm.Email;
            s.Payed = sm.Payed;
            s.FacturationAddress = sm.FacturationAddress;
            s.FacturationName = sm.FacturationName;

            return s;
        }
    }
}