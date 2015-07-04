using Aug2015Backend.Models;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters
{
    public class VacationETMAdapter
    {
        private AgeRangeETMAdapter arAdapter= new AgeRangeETMAdapter();
        public VacationModel MapData(Aug2015Backend.Entities.Vacation v)
        {
            VacationModel mappedVacation = new VacationModel();

            if (v != null)
            {
                ICollection<AgeRangeModel> ageRanges = arAdapter.MapData(v.AgeRange);
                mappedVacation.Leeftijd = ageRanges;
                mappedVacation.Titel = v.Titel;
                mappedVacation.Id = v.Id;            
            }          

            return mappedVacation;
        }
    }
}