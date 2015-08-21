using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters
{
    public class AgeRangeETMAdapter
    {
        public AgeRangeModel MapData(Aug2015Backend.Entities.AgeRange ar)
        {
            AgeRangeModel mappedAgeRange = new AgeRangeModel();
            if (ar != null)
            {                         

                    mappedAgeRange.Id = ar.Id;
                    mappedAgeRange.Min_leeftijd = ar.Min_leeftijd;
                    mappedAgeRange.Max_leeftijd = ar.Max_leeftijd;
                    mappedAgeRange.VacationId = ar.Vacation.Id;
              
            }
            return mappedAgeRange;
        }
    }
}