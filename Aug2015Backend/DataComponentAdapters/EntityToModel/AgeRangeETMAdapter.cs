using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters
{
    public class AgeRangeETMAdapter
    {
        public ICollection<AgeRangeModel> MapData(ICollection<Aug2015Backend.Entities.AgeRange> ar)
        {
            ICollection<AgeRangeModel> ageRanges = new List<AgeRangeModel>();

            foreach (Aug2015Backend.Entities.AgeRange range in ar)
            { 

                AgeRangeModel mappedAgeRange = new AgeRangeModel();

                mappedAgeRange.Id = range.Id;
                mappedAgeRange.Min_leeftijd = range.Min_leeftijd;
                mappedAgeRange.Max_leeftijd = range.Max_leeftijd;
                mappedAgeRange.VacationId = range.VacationId;

                ageRanges.Add(mappedAgeRange);
            }
            return ageRanges;
        }

    }
}