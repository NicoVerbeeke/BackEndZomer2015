using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters.EntityToModel
{
    public class GroupETMAdapter
    {
        public ICollection<GroupModel> MapData(ICollection<Group> groups)
        {
            AgeRangeETMAdapter arAdapter = new AgeRangeETMAdapter();
            ICollection<GroupModel> mappedGroups = new List<GroupModel>();
            foreach (Group g in groups)
            {
                GroupModel gm = new GroupModel();

                gm.Id = g.Id;
                gm.GroupNr = g.GroupNr;
                gm.AgeRange = arAdapter.MapData(new List<AgeRange>(){g.AgeRange}).ToList()[0];
                gm.VacId = g.VacationId;
                mappedGroups.Add(gm);
            }
            return mappedGroups;
        }
    }
}