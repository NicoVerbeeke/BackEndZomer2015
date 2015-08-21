using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Aug2015Backend.Models.ModelHelpers
{
    public class SubscriptionModel
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "SubscribedUserId")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "Voornaam")]
        public String FirstName { get; set; }

        [JsonProperty(PropertyName = "Naam")]
        public String LastName { get; set; }

        [JsonProperty(PropertyName = "Rijksregisternummer_Vakantieganger")]
        public String RNR { get; set; }

        [JsonProperty(PropertyName = "Straat")]
        public String Street { get; set; }

        [JsonProperty(PropertyName = "Nr")]
        public String HouseNr { get; set; }

        [JsonProperty(PropertyName = "Postcode")]
        public String PostalCode { get; set; }

        [JsonProperty(PropertyName = "Gemeente")]
        public String City { get; set; }

        [JsonProperty(PropertyName = "SubscriptionForVacationId")]
        public int VacId { get; set; }

        [JsonProperty(PropertyName = "Naam_Moeder")]
        public String Name_Mother { get; set; }

        [JsonProperty(PropertyName = "Rijksregisternummer_Moeder")]
        public String RNR_Mother { get; set; }

        [JsonProperty(PropertyName = "Naam_Vader")]
        public String Name_Father { get; set; }

        [JsonProperty(PropertyName = "Rijksregisternummer_Vader")]
        public String RNR_Father { get; set; }

        [JsonProperty(PropertyName = "Tel")]
        public String TelephoneNumber { get; set; }

        [JsonProperty(PropertyName = "E-mail")]
        public String Email { get; set; }

        [JsonProperty(PropertyName = "Adres_Betalingspersoon")]
        public String FacturationAddress  { get; set; }

        [JsonProperty(PropertyName = "Naam_Betalingspersoon")]
        public String FacturationName { get; set; }

        [JsonProperty(PropertyName = "Betaald")]
        public Boolean Payed { get; set; }
    }
}