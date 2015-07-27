using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aug2015Backend.DataComponentAdapters.ModelToEntity
{
    class PeriodMTEAdapter
    {
        //private VacationMTEAdapter vacationAdapter = new VacationMTEAdapter();

        public ICollection<Period> MapData(ICollection<PeriodModel> collection, int p)
        {
            ICollection<Period> periods = new List<Period>();

            foreach (PeriodModel pm in collection)
            {
                Period period = new Period();

                period.Id = pm.Id;
                period.PeriodNr = pm.PeriodNr;
                period.DateStart = pm.DateStart;
                period.DateEnd = pm.DateEnd;
                //period.Vacation = vacationAdapter.getVacation(p);
                period.VacationId = p;

                periods.Add(period);
            }

            return periods;
        }
    }
}
