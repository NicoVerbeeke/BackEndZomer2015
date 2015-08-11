using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.Models.ModelHelpers
{
    //for use with OAuth
    public class RegistrationModel
    {
        public String UserName { get; set; }

        public String Password { get; set; }

        public String ConfirmPassword { get; set; }
    }
}