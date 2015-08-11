using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.Models.ModelHelpers
{
    public class SubscriptionModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "subscribedUserId")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "subscriptionForVacationId")]
        public int VacId { get; set; }
    }
}