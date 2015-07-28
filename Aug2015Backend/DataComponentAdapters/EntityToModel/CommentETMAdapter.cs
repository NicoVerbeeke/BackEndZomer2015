using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters.EntityToModel
{
    public class CommentETMAdapter
    {
        public ICollection<CommentModel> MapData(ICollection<Comment> comments)
        {
            ICollection<CommentModel> commentModels = new List<CommentModel>();
            if (comments != null)
            {
                foreach (Comment c in comments)
                {
                    CommentModel m = new CommentModel();

                    m.Id = c.Id;
                    m.Titel = c.Titel;
                    m.Text = c.Text;
                    m.Url = c.Url;
                    m.VacId = c.VacationId;
                    commentModels.Add(m);
                }
            }
            return commentModels;
        }
    }
}