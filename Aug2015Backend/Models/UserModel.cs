﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aug2015Backend.Models
{
    public class UserModel : IdentityUser
    {
        [Required]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bevestig wachtwoord")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Rijksregisternummer")]
        public String RNR { get; set; }

        [Required]
        [Display(Name = "Voornaam")]
        public String FirstName { get; set; }

        [Required]
        [Display(Name = "Naam")]
        public String LastName { get; set; }

        [Required]
        [Display(Name = "Straat")]
        public String Street { get; set; }

        [Required]
        [Display(Name = "Nr")]
        public String HouseNr { get; set; }

        [Required]
        [Display(Name = "Bus")]
        public String Bus { get; set; }

        [Required]
        [Display(Name = "Gemeente")]
        public String City { get; set; }

        [Required]
        [Display(Name = "Postcode")]
        public String PostalCode { get; set; }

        [Required]
        [Display(Name = "e-mail")]
        public String Email { get; set; }
    }
}