using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aug2015Backend.DataComponentAdapters.ModelToEntity
{
    class GroupMTEAdapter
    {
       // private VacationMTEAdapter vacationAdapter = new VacationMTEAdapter();

        public ICollection<Group> MapData(ICollection<GroupModel> collection, int p)
        {
            ICollection<Group> groups = new List<Group>();

            foreach (GroupModel gm in collection)
            {
                Group g = new Group();

                g.Id = gm.Id;
                g.GroupNr = gm.GroupNr;
                g.AgeRangeId = gm.AgeRange.Id;
              //  g.Vacation = vacationAdapter.getVacation(p);
                g.VacationId = p;

                groups.Add(g);
            }

            return groups;
        }
    }
}
