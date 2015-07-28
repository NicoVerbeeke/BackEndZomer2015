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
        public ICollection<String> MapData(ICollection<IncludedItem> items)
        {
            ICollection<String> models = new List<string>();
            if (items != null)
            {
                foreach (IncludedItem i in items)
                {

                    models.Add(i.Item);
                }
            }
            return models;
        }
    }
}