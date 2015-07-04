using Aug2015Backend.DataBaseContext;
using Aug2015Backend.DataComponentAdapters;
using Aug2015Backend.Entities;
using Aug2015Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Aug2015Backend.Controllers
{
    public class VacationController : ApiController
    {   
        private VacationAdapter _vacAdapter;
        private DataContext _db;

        public VacationController(){
            _vacAdapter = new VacationAdapter();
            _db = new DataContext();
        }

        // api/vacation
        public IEnumerable<VacationModel> GetAllProducts()
        {
            ICollection<VacationModel> vacationModels = new List<VacationModel>();
            
            var query = from b in _db.Vacations select b;

            foreach(Vacation vac in query){
                 vacationModels.Add(_vacAdapter.MapData(vac));
                    
            }

            return vacationModels;
        }

        public VacationModel GetVacation(int id)
        {
            var query = _db.Vacations.Where(b => b.Id == id).Select(b => b).FirstOrDefault();

            return _vacAdapter.MapData(query);
        }
    }
}
