using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters.EntityToModel
{
    public class PictureETMAdapter
    {
        public ICollection<PictureModel> MapData(ICollection<Picture> pictures)
        {
            ICollection<PictureModel> mappedPictures = new List<PictureModel>();

            foreach (Picture p in pictures)
            {
                if(p != null){
                    mappedPictures.Add(MapData(p));
                }
            }
            return mappedPictures;
        }

        public PictureModel MapData(Picture p){
            if (p != null) { 
                PictureModel pm = new PictureModel();
                pm.Id = p.Id;
                pm.Titel = p.Titel;
                pm.Description = p.Description;
                pm.Url = p.Url;
                pm.VacId = p.VacationId;
                return pm;
            }
            else
            {
                return new PictureModel();
            }
        }
    }
}