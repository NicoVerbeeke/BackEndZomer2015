using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters.EntityToModel
{
    public class PeriodETMAdapter
    {
        public PeriodModel MapData(Period p)
        {        
            PeriodModel pm = new PeriodModel();
            pm.Id = p.Id;
            pm.PeriodNr = p.PeriodNr;
            pm.DateStart = p.DateStart;
            pm.DateEnd = p.DateEnd;
            pm.VacId = p.Vacation.Id;
            return pm;
        }
    }
}