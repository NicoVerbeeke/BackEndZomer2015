using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.Models.ModelHelpers
{
    public class GroupModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "vacation")]
        public int VacId { get; set; }

        [JsonProperty(PropertyName = "groep")]
        public int GroupNr { get; set; }

        [JsonProperty(PropertyName = "leeftijd")]
        public virtual AgeRangeModel AgeRange { get; set; }
    }
}