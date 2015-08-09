using Aug2015Backend.DataBaseContext;
using Aug2015Backend.DataComponentAdapters;
using Aug2015Backend.Entities;
using Aug2015Backend.Models;
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
