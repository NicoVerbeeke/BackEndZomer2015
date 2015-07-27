using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.Models.ModelHelpers
{
    public class PeriodModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "vacation")]
        public int VacId { get; set; }

        [JsonProperty(PropertyName = "periode")]
        public int PeriodNr { get; set; }

        [JsonProperty(PropertyName = "date_begin")]
        public DateTime DateStart { get; set; }

        [JsonProperty(PropertyName = "date_end")]
        public DateTime DateEnd { get; set; }
    }
}