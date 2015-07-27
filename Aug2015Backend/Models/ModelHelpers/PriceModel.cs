using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.Models.ModelHelpers
{
    public class PriceModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "vacation")]
        public int VacId { get; set; }

        [JsonProperty(PropertyName = "basis")]
        public double BasePrice { get; set; }

        [JsonProperty(PropertyName = "ster_enkel")]
        public double SingleStarPrice { get; set; }

        [JsonProperty(PropertyName = "ster_dubbel")]
        public double DoubleStarPrice { get; set; }
    }
}