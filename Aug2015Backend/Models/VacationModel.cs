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
        public virtual AgeRangeModel Leeftijd { get; set; }

        [JsonProperty(PropertyName = "waar")]
        public virtual LocationModel Location { get; set; }


        [JsonProperty(PropertyName = "wanneer")]
        public virtual PeriodModel When { get; set; }

        [JsonProperty(PropertyName = "aantal_deelnemers")]
        public int NumberOfParticipants { get; set; }

        [JsonProperty(PropertyName = "prijs")]
        public virtual PriceModel Cost { get; set; }

        [JsonProperty(PropertyName = "inbegrepen")]
        public virtual ICollection<IncludedItemModel> Included { get; set; }

        [JsonProperty(PropertyName = "informatie")]
        public virtual ContactInformationModel ContactInformation { get; set; }

        [JsonProperty(PropertyName = "opmerking")]
        public virtual ICollection<CommentModel> Comment { get; set; }

        [JsonProperty(PropertyName = "promotext")]
        public String PromoText { get; set; }

        [JsonProperty(PropertyName = "foto")]
        public virtual ICollection<PictureModel> Pictures { get; set; }

        [JsonProperty(PropertyName = "cover_foto")]
        public virtual PictureModel Cover { get; set; }

        [JsonProperty(PropertyName = "fiscaal_voordeel")]
        public virtual bool Tax_Benefit { get; set; }
    }
}