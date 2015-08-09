using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aug2015Backend.DataComponentAdapters.ModelToEntity
{
    class IncludedItemMTEAdapter
    {
        //private VacationMTEAdapter vacationAdapter = new VacationMTEAdapter();

        public ICollection<IncludedItem> MapData(ICollection<IncludedItemModel> collection)
        {
            ICollection<IncludedItem> items = new List<IncludedItem>();
            foreach (IncludedItemModel s in collection)
            {
                items.Add(MapData(s));
            }
            return items;
        }

        public IncludedItem MapData(IncludedItemModel s)
        {
            IncludedItem i = new IncludedItem();
            i.Id = s.Id;
            i.Item = s.Item;
            i.VacationId = s.VacId;
            return i;
        }
    }
}
