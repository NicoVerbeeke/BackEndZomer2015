using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aug2015Backend.DataComponentAdapters.ModelToEntity
{
    public class PictureMTEAdapter
    {
        //private VacationMTEAdapter vacationAdapter = new VacationMTEAdapter();

        public Picture MapData(PictureModel pictureModel)
        {
            Picture pic = new Picture();

            if (pictureModel != null)
            {
                pic.Id = pictureModel.Id;
                pic.Titel = pictureModel.Titel;
                pic.Url = pictureModel.Url;
                pic.Description = pictureModel.Description;
                //pic.Vacation = vacationAdapter.getVacation(p);
                pic.VacationId = pictureModel.VacId;
            }
            return pic;
        }

        public ICollection<Picture> MapData(ICollection<PictureModel> collection)
        {
            ICollection<Picture> pictures = new List<Picture>();

            foreach (PictureModel pm in collection)
            {
                pictures.Add(MapData(pm));
            }

            return pictures;
        }
    }
}
