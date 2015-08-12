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
            AgeRangeModel range = new AgeRangeModel();
            if (ar != null)
            {       
                    AgeRangeModel mappedAgeRange = new AgeRangeModel();

                    mappedAgeRange.Id = range.Id;
                    mappedAgeRange.Min_leeftijd = range.Min_leeftijd;
                    mappedAgeRange.Max_leeftijd = range.Max_leeftijd;
                    mappedAgeRange.VacationId = range.VacationId;
              
            }
            return range;
        }

    }
}