using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.Models.ModelHelpers
{
    public class AgeRangeModel
    {
        private int _minAge = 0;
        private int _maxAge = int.MaxValue;

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "vacationId")]
        public int VacationId { get; set; }

        [JsonProperty(PropertyName = "min_leeftijd")]
        public int Min_leeftijd
        {
            get { return _minAge; }

            set
            {
                if (!(value < 0 || value > Max_leeftijd))
                {
                    _minAge = value;
                }
            }
        }

        [JsonProperty(PropertyName = "max_leeftijd")]
        public int Max_leeftijd
        {
            get { return _maxAge; }

            set
            {
                if (!(value < Min_leeftijd || value > 100))
                {
                   _maxAge = value;
                }
            }
        }
    }
}