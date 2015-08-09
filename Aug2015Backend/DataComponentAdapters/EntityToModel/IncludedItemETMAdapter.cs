using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters.EntityToModel
{
    public class IncludedItemETMAdapter
    {
        public ICollection<IncludedItemModel> MapData(ICollection<IncludedItem> items)
        {
            ICollection<IncludedItemModel> models = new List<IncludedItemModel>();
            if (items != null)
            {
                foreach (IncludedItem i in items)
                {
                    
                    models.Add(MapData(i));
                }
            }
            return models;
        }

        public IncludedItemModel MapData(IncludedItem i){
            IncludedItemModel item = new IncludedItemModel();
            item.Id = i.Id;
            item.VacId = i.VacationId;
            item.Item = i.Item;
            return item;
        }
    }
}