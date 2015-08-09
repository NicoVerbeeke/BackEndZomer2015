using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aug2015Backend.DataComponentAdapters.ModelToEntity
{
    class LocationMTEAdapter
    {
        //private VacationMTEAdapter vacationAdapter = new VacationMTEAdapter();

        public Location MapData(LocationModel locationModel)
        {
            Location l = new Location();

            l.Id = locationModel.Id;
            l.City = locationModel.City;
            l.VacationDomain = locationModel.VacationDomain;
            return l;
        }
    }
}
