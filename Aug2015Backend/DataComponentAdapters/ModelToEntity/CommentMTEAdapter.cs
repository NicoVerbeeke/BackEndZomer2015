using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aug2015Backend.DataComponentAdapters.ModelToEntity
{
    class CommentMTEAdapter
    {
        //private VacationMTEAdapter vacationAdapter = new VacationMTEAdapter();

        public ICollection<Comment> MapData(ICollection<CommentModel> collection, int p)
        {
            ICollection<Comment> comments = new List<Comment>();

            foreach (CommentModel m in collection)
            {
                comments.Add(MapData(m,p));
            }
            return comments;
        }

        public Comment MapData(CommentModel m, int p) {         
            Comment c = new Comment();
            c.Id = m.Id;
            c.Text = m.Text;
            c.Titel = m.Titel;
            c.Url = m.Url;
            c.VacationId = p;
            return c;
        }
    }
}
