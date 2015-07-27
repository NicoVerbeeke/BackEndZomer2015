using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters.EntityToModel
{
    public class LocationETMAdapter
    {
        public LocationModel MapData(Location l)
        {
            LocationModel lm = new LocationModel();

            lm.Id = l.Id;
            lm.VacationDomain = l.VacationDomain;
            lm.City = l.City;
            lm.VacId = l.Vacation.Id ;

            return lm;
        }
    }
}