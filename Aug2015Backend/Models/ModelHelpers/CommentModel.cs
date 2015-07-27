using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.Models.ModelHelpers
{
    public class CommentModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "vacation")]
        public int VacId { get; set; }

        [JsonProperty(PropertyName = "titel")]
        public string Titel { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}