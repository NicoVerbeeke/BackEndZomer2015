using Aug2015Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aug2015Backend.DataComponentAdapters.ModelToEntity
{
    class IncludedItemMTEAdapter
    {
        //private VacationMTEAdapter vacationAdapter = new VacationMTEAdapter();

        public ICollection<IncludedItem> MapData(ICollection<string> collection, int p)
        {
            ICollection<IncludedItem> items = new List<IncludedItem>();
            foreach (string s in collection)
            {
                IncludedItem i = new IncludedItem();

                i.Item = s;
                i.VacationId = p;
                //i.Vacation = vacationAdapter.getVacation(p);

                items.Add(i);
            }
            return items;
        }
    }
}
