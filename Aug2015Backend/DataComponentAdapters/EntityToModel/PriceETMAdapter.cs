using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters.EntityToModel
{
    public class PriceETMAdapter
    {
        public PriceModel MapData(Price p)
        {
            PriceModel pm = new PriceModel();
            if (p != null)
            {
                pm.Id = p.Id;
                pm.SingleStarPrice = p.SingleStarPrice;
                pm.BasePrice = p.BasePrice;
                pm.DoubleStarPrice = p.DoubleStarPrice;
                pm.VacId = p.Vacation.Id;
            }
            return pm;            
        }
    }
}