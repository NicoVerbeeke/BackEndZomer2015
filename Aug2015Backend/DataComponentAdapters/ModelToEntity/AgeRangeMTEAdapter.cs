using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters
{
    public class AgeRangeMTEAdapter
    {
        public ICollection<AgeRange> MapData(ICollection<AgeRangeModel> ar, int vacId)
        {
            ICollection<AgeRange> ageRanges = new List<AgeRange>();

            foreach (AgeRangeModel range in ar)
            { 

                AgeRange mappedAgeRange = new AgeRange();

                mappedAgeRange.Id = range.Id;
                mappedAgeRange.Min_leeftijd = range.Min_leeftijd;
                mappedAgeRange.Max_leeftijd = range.Max_leeftijd;
                mappedAgeRange.VacationId = vacId;

                ageRanges.Add(mappedAgeRange);
            }
            return ageRanges;
        }

    }
}