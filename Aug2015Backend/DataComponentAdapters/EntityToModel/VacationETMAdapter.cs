﻿using Aug2015Backend.DataBaseContext;
using Aug2015Backend.DataComponentAdapters.EntityToModel;
using Aug2015Backend.Entities;
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
        private CommentETMAdapter commentAdapter = new CommentETMAdapter();
        private ContactInformationETMAdapter contactInformationAdapter = new ContactInformationETMAdapter();
        private LocationETMAdapter locationAdapter = new LocationETMAdapter();
        private PictureETMAdapter pictureAdapter = new PictureETMAdapter();
        private PriceETMAdapter priceAdapter = new PriceETMAdapter();
        private IncludedItemETMAdapter itemAdapter = new IncludedItemETMAdapter();
        private PeriodETMAdapter periodAdapter = new PeriodETMAdapter();

        public VacationModel MapData(Aug2015Backend.Entities.Vacation v)
        {
            VacationModel mappedVacation = new VacationModel();
            

            if (v != null)
            {
                mappedVacation.Pictures = pictureAdapter.MapData(v.Picture);
                mappedVacation.Cover = pictureAdapter.MapData(v.Cover);
                mappedVacation.PromoText = v.PromoText;
                mappedVacation.ContactInformation = contactInformationAdapter.MapData(v.ContactInformation);
                mappedVacation.Included = itemAdapter.MapData(v.Included);
                mappedVacation.Cost = priceAdapter.MapData(v.Cost);
                mappedVacation.NumberOfParticipants = v.NumberOfParticipants; 
                mappedVacation.Location = locationAdapter.MapData(v.Location);
                mappedVacation.When = periodAdapter.MapData(v.When);
                ICollection<CommentModel> comments = commentAdapter.MapData(v.Comment);
                mappedVacation.Comment = comments;
                mappedVacation.Leeftijd = arAdapter.MapData(v.AgeRange);
                mappedVacation.Titel = v.Titel;
                mappedVacation.Id = v.Id;
                mappedVacation.Tax_Benefit = v.Tax_Benefit;
            }          

            return mappedVacation;
        }

    }
}