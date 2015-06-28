using Aug2015Backend.Models;
using Aug2015Backend.Models.ModelHelpers;
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
        public IEnumerable<Vacation> GetAllProducts()
        {
            return vacations;
        }

        public IHttpActionResult GetVacation(int id)
        {
            var vacation = vacations.FirstOrDefault((v) => v.Id == id);
            if (vacation == null)
            {
                return NotFound();
            }
            return Ok(vacation);
        }

        Vacation[] vacations = new Vacation[]
        {
                new Vacation {Titel="kinderboerderij", Leeftijd=new AgeRange[]{new AgeRange{Min_leeftijd = 4, Max_leeftijd = 6}, new AgeRange{Min_leeftijd = 7, Max_leeftijd = 10}}},
                new Vacation {Titel="krokusvakantie aan zee", Leeftijd=new AgeRange[]{new AgeRange{Min_leeftijd = 5, Max_leeftijd = 16}}}
        };


    }
}
