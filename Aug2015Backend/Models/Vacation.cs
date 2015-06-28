using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.Models
{
    public class Vacation
    {
        public Vacation()
        {
            DateTime now = DateTime.Now;
            _id = now.Year + now.DayOfYear + now.Minute + now.Millisecond;
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            private set { _id = _id; }
        }
        public String Titel { get; set; }
        public AgeRange[] Leeftijd { get; set; }


    }
}