using Aug2015Backend.DataBaseContext;
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
        private DataContext _db = new DataContext();
        
        public ICollection<AgeRange> MapData(ICollection<AgeRangeModel> ar, int vacId)
        {
            ICollection<AgeRange> ageRanges = new List<AgeRange>();


            foreach (AgeRangeModel range in ar)
            { 
                ageRanges.Add(MapData(range, vacId));
            }
            return ageRanges;
        }

        public AgeRange MapData(AgeRangeModel arm, int vacId)
        {
            AgeRange mappedAgeRange = new AgeRange();

            mappedAgeRange.Id = arm.Id;
            mappedAgeRange.Min_leeftijd = arm.Min_leeftijd;
            mappedAgeRange.Max_leeftijd = arm.Max_leeftijd;
            mappedAgeRange.Vacation = _db.Vacations.Find(vacId);
            return mappedAgeRange;
        }

    }
}