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
            model.FirstName = s.FirstName;
            model.LastName = s.LastName;
            model.RNR = s.RNR;
            model.Street = s.Street;
            model.HouseNr = s.HouseNr;
            model.PostalCode = s.PostalCode;
            model.City = s.City;
            model.Name_Mother = s.Name_Mother;
            model.Name_Father = s.Name_Father;
            model.RNR_Mother = s.RNR_Mother;
            model.RNR_Father = s.RNR_Father;
            model.TelephoneNumber = s.TelephoneNumber;
            model.Email = s.Email;
            model.Payed = s.Payed;
            model.FacturationAddress = s.FacturationAddress;
            model.FacturationName = s.FacturationName;

            return model;
        }
    }
}