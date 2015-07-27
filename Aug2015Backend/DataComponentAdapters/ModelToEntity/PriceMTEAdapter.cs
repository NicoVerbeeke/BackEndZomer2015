using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aug2015Backend.DataComponentAdapters.ModelToEntity
{
    class PriceMTEAdapter
    {
        //private VacationMTEAdapter vacationAdapter = new VacationMTEAdapter();

        public Price MapData(PriceModel priceModel, int p)
        {
            Price price = new Price();

            price.Id = priceModel.Id;
            price.BasePrice = priceModel.BasePrice;
            price.SingleStarPrice = priceModel.SingleStarPrice;
            price.DoubleStarPrice = priceModel.DoubleStarPrice;
            //price.Vacation = vacationAdapter.getVacation(p);

            return price;
        }
    }
}
