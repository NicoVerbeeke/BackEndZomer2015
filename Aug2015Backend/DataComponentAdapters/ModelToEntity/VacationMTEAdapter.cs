﻿using Aug2015Backend.Entities;
using Aug2015Backend.Models;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aug2015Backend.DataComponentAdapters.ModelToEntity;
using Aug2015Backend.DataBaseContext;

namespace Aug2015Backend.DataComponentAdapters
{
    public class VacationMTEAdapter
    {
        private DataContext dataContext = new DataContext();

        private AgeRangeMTEAdapter arAdapter= new AgeRangeMTEAdapter();
        private CommentMTEAdapter commentAdapter = new CommentMTEAdapter();
        private ContactInformationMTEAdapter contactInformationAdapter = new ContactInformationMTEAdapter();
        private LocationMTEAdapter locationAdapter = new LocationMTEAdapter();
        private PeriodMTEAdapter periodAdapter = new PeriodMTEAdapter();
        private PictureMTEAdapter pictureAdapter = new PictureMTEAdapter();
        private PriceMTEAdapter priceAdapter = new PriceMTEAdapter();
        private IncludedItemMTEAdapter itemAdapter = new IncludedItemMTEAdapter();

        public Vacation MapData(VacationModel v)
        {
            Vacation mappedVacation = new Vacation();

            if (v != null)
            {
                if (v.Cover != null)
                {
                    mappedVacation.Cover = pictureAdapter.MapData(v.Cover);
                }
                mappedVacation.PromoText = v.PromoText;
                mappedVacation.ContactInformation = contactInformationAdapter.MapData(v.ContactInformation, v.Id);
                mappedVacation.Included = itemAdapter.MapData(v.Included);
                mappedVacation.Cost = priceAdapter.MapData(v.Cost, v.Id);
                mappedVacation.NumberOfParticipants = v.NumberOfParticipants;
                mappedVacation.When = periodAdapter.MapData(v.When, v.Id);
                mappedVacation.Location = locationAdapter.MapData(v.Location);
                mappedVacation.Comment = commentAdapter.MapData(v.Comment, v.Id);               
                mappedVacation.AgeRange = arAdapter.MapData(v.Leeftijd, v.Id);
                mappedVacation.Titel = v.Titel;
                mappedVacation.Id = v.Id;
                mappedVacation.Tax_Benefit = v.Tax_Benefit;
            }          

            return mappedVacation;
        }

        public Vacation getVacation(int id)
        {
            return dataContext.Vacations.Where(b => b.Id == id).Select(b => b).FirstOrDefault();
        }
    }
}