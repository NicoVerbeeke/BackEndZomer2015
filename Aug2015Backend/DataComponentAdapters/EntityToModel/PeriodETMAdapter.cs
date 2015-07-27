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
        public ICollection<PeriodModel> MapData(ICollection<Period> periods)
        {
            ICollection<PeriodModel> mappedPeriods = new List<PeriodModel>();

            foreach (Period p in periods)
            {
                PeriodModel pm = new PeriodModel();
                pm.Id = p.Id;
                pm.PeriodNr = p.PeriodNr;
                pm.DateStart = p.DateStart;
                pm.DateEnd = p.DateEnd;
                pm.VacId = p.Vacation.Id;
                mappedPeriods.Add(pm);
            }

            return mappedPeriods;
        }
    }
}