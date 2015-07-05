using Aug2015Backend.Models.ModelHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aug2015Backend.Models
{
    public partial class VacationModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set;}
        
        [StringLength(200)]
        [JsonProperty(PropertyName = "titel")]
        public String Titel { get; set; }

        [JsonProperty(PropertyName = "leeftijd")]
        public virtual ICollection <AgeRangeModel> Leeftijd { get; set; }

    }
}