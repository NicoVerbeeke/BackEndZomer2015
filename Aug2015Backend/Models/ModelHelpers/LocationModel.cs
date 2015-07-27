using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.Models.ModelHelpers
{
    public class LocationModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "vacation")]
        public int VacId { get; set; }

        [JsonProperty(PropertyName = "vakantie_domein")]
        public string VacationDomain { get; set; }

        [JsonProperty(PropertyName = "stad")]
        public string City { get; set; }
    }
}