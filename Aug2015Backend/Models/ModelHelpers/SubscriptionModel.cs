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

        [Required]
        [JsonProperty(PropertyName = "SubscribedUserId")]
        public int UserId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Voornaam")]
        public String FirstName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Naam")]
        public String LastName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Rijksregisternummer_Vakantieganger")]
        public String RNR { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Straat")]
        public String Street { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Nr")]
        public String HouseNr { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Postcode")]
        public String PostalCode { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Gemeente")]
        public String City { get; set; }

        [Required]
        [JsonProperty(PropertyName = "SubscriptionForVacationId")]
        public int VacId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Naam_Moeder")]
        public String Name_Mother { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Rijksregisternummer_Moeder")]
        public String RNR_Mother { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Naam_Vader")]
        public String Name_Father { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Rijksregisternummer_Vader")]
        public String RNR_Father { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Tel")]
        public String TelephoneNumber { get; set; }

        [Required]
        [JsonProperty(PropertyName = "E-mail")]
        public String Email { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Adres_Betalingspersoon")]
        public String FacturationAddress  { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Naam_Betalingspersoon")]
        public String FacturationName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "Betaald")]
        public Boolean Payed { get; set; }
    }
}