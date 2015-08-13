using Aug2015Backend.DataBaseContext;
using Aug2015Backend.DataComponentAdapters;
using Aug2015Backend.DataComponentAdapters.ModelToEntity;
using Aug2015Backend.Entities;
using Aug2015Backend.Models;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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

        // api/vacation -> GET Verb
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

        // api/vacation/{id} -> GET Verb
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

        // api/vacation -> PUT Verb
        // update a single vacation, the id is fetched from the model that needs to be send in the body of the request
        [Authorize(Roles="Admin")]
        public int PutVacation(VacationModel vacModel)
        {
            var original = _db.Vacations.Find(vacModel.Id);

            if (original != null)
            {
                original.Titel = vacModel.Titel;


                var originalAgeRange = original.AgeRange;
                _db.Entry(originalAgeRange).CurrentValues.SetValues(new AgeRangeMTEAdapter().MapData(vacModel.Leeftijd, vacModel.Id));
                  
                var originalLocation = original.Location;
                _db.Entry(originalLocation).CurrentValues.SetValues(new LocationMTEAdapter().MapData(vacModel.Location));
                
                original.NumberOfParticipants = vacModel.NumberOfParticipants;

                var originalCost = original.Cost;
                _db.Entry(originalCost).CurrentValues.SetValues(new PriceMTEAdapter().MapData(vacModel.Cost, vacModel.Id));

                var originalPeriod = original.When;
                _db.Entry(originalPeriod).CurrentValues.SetValues(new PeriodMTEAdapter().MapData(vacModel.When, vacModel.Id));

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


        
        // api/vacation -> POST Verb
        // add a vacation to the list
        [Authorize(Roles = "Admin")]
        public void PostVacation(VacationModel vacModel)
        {
            Vacation vac = _vacToEntityAdapter.MapData(vacModel);

            _db.Vacations.Add(vac);
            _db.SaveChanges();                       
        }


        // api/vacation/{id} -> DELETE Verb
        // deletes the vacation with the id supplied in the url
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage DeleteVacation(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();          
            var VacationToDelete = _db.Vacations.Where(v => v.Id == id).SingleOrDefault();

      
            if (VacationToDelete != null)
            {
               

                _db.Entry(VacationToDelete.Cost).State = EntityState.Deleted;
                _db.Entry(VacationToDelete.AgeRange).State = EntityState.Deleted;
                _db.Entry(VacationToDelete.When).State = EntityState.Deleted;
                _db.Entry(VacationToDelete.ContactInformation).State = EntityState.Deleted;
                _db.Entry(VacationToDelete.Location).State = EntityState.Deleted;
                _db.Entry(VacationToDelete.Cover).State = EntityState.Deleted;
                _db.Vacations.Remove(VacationToDelete);
                _db.SaveChanges();
                response.StatusCode = HttpStatusCode.OK;

            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
            }
            return response;
        }
    }
}
