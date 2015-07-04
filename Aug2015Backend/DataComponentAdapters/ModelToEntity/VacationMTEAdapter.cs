using Aug2015Backend.Entities;
using Aug2015Backend.Models;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters
{
    public class VacationMTEAdapter
    {
        private AgeRangeMTEAdapter arAdapter= new AgeRangeMTEAdapter();
        public Vacation MapData(VacationModel v)
        {
            Vacation mappedVacation = new Vacation();

            if (v != null)
            {
                ICollection<AgeRange> ageRanges = arAdapter.MapData(v.Leeftijd, v.Id);
                mappedVacation.AgeRange = ageRanges;
                mappedVacation.Titel = v.Titel;
                mappedVacation.Id = v.Id;            
            }          

            return mappedVacation;
        }
    }
}