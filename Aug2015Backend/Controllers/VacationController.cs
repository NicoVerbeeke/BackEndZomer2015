using Aug2015Backend.DataBaseContext;
using Aug2015Backend.DataComponentAdapters;
using Aug2015Backend.DataComponentAdapters.ModelToEntity;
using Aug2015Backend.Entities;
using Aug2015Backend.Models;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Aug2015Backend.Controllers
{
    public class VacationController : ApiController
    {   
        private VacationETMAdapter _vacToModelAdapter;
        private VacationMTEAdapter _vacToEntityAdapter;
        private DataContext _db;

        public VacationController(){
            _vacToModelAdapter = new VacationETMAdapter();
            _vacToEntityAdapter = new VacationMTEAdapter();
            _db = new DataContext();
        }

        // api/vacation
        // retrieve all vacations
        public IEnumerable<VacationModel> GetAllVacations()
        {
            ICollection<VacationModel> vacationModels = new List<VacationModel>();
            
            var query = from b in _db.Vacations select b;

            foreach(Vacation vac in query){
                 vacationModels.Add(_vacToModelAdapter.MapData(vac));                    
            }

            return vacationModels;
        }

        // api/vacation/{id}
        // retrieve a single vacation with the matching Id
        public HttpResponseMessage GetVacation(int id)
        {
            HttpResponseMessage result = new HttpResponseMessage();

            var query = _db.Vacations.Where(b => b.Id == id).Select(b => b).FirstOrDefault();
            VacationModel vacationModel = _vacToModelAdapter.MapData(query);

            if (vacationModel.Id == 0)
            {
                
                result = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.OK, vacationModel);
            }
            return result;            
        }

        public int PutVacation(VacationModel vacModel)
        {
            var original = _db.Vacations.Find(vacModel.Id);

            if (original != null)
            {
                original.Titel = vacModel.Titel;
                
                foreach (AgeRange ar in original.AgeRange)
                {
                    foreach (AgeRangeModel arm in vacModel.Leeftijd)
                    {
                        if(arm.Id == ar.Id)
                        _db.Entry(ar).CurrentValues.SetValues(new AgeRangeMTEAdapter().MapData(arm, vacModel.Id));

                    }
                }
                var originalLocation = original.Location;
                _db.Entry(originalLocation).CurrentValues.SetValues(new LocationMTEAdapter().MapData(vacModel.Location));

                foreach (Group g in original.Who)
                {
                    foreach (GroupModel gm in vacModel.Who)
                    {
                        if (g.Id == gm.Id)
                            _db.Entry(g).CurrentValues.SetValues(new GroupMTEAdapter().MapData(gm, vacModel.Id));
                    }
                }

                foreach (Period p in original.When)
                {
                    foreach (PeriodModel pm in vacModel.When)
                    {
                        if (p.Id == pm.Id)
                            _db.Entry(p).CurrentValues.SetValues(new PeriodMTEAdapter().MapData(pm, vacModel.Id));
                    }
                }
                
                original.NumberOfParticipants = vacModel.NumberOfParticipants;
                var originalCost = original.Cost;
                _db.Entry(originalCost).CurrentValues.SetValues(new PriceMTEAdapter().MapData(vacModel.Cost, vacModel.Id));

                foreach (IncludedItem i in original.Included)
                {
                    foreach (IncludedItemModel im in vacModel.Included)
                    {
                        if (i.Id == im.Id)
                            _db.Entry(i).CurrentValues.SetValues(new IncludedItemMTEAdapter().MapData(im));
                    }
                } 

                var originalContactInformation = original.ContactInformation;
                _db.Entry(originalContactInformation).CurrentValues.SetValues(new ContactInformationMTEAdapter().MapData(vacModel.ContactInformation, vacModel.Id));

                foreach (Comment c in original.Comment)
                {
                    foreach (CommentModel cm in vacModel.Comment)
                    {
                        if (c.Id == cm.Id)
                            _db.Entry(c).CurrentValues.SetValues(new CommentMTEAdapter().MapData(cm, vacModel.Id));
                    }
                }                
                
                original.PromoText = vacModel.PromoText;

                foreach (Picture p in original.Picture)
                {
                    foreach (PictureModel pm in vacModel.Pictures)
                    {
                        if (p.Id == pm.Id)
                            _db.Entry(p).CurrentValues.SetValues(new PictureMTEAdapter().MapData(pm));
                    }
                }  
                var originalCover = original.Cover;
                _db.Entry(originalCover).CurrentValues.SetValues(new PictureMTEAdapter().MapData(vacModel.Cover));

                original.Tax_Benefit = vacModel.Tax_Benefit;
                _db.SaveChanges();
            }
            return original.Id;
        }


        
        // api/vacation
        // add a vacation to the list
        public void PostVacation(VacationModel vacModel)
        {
            Vacation vac = _vacToEntityAdapter.MapData(vacModel);

            _db.Vacations.Add(vac);
            _db.SaveChanges();                       
        }
    }
}
