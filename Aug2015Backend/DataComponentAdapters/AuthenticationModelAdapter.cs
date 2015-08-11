using Aug2015Backend.Models;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters
{
    public class AuthenticationModelAdapter
    {

        public RegistrationModel CreateRegistrationModel(UserModel um)
        {

            RegistrationModel model = new RegistrationModel();

            model.UserName = um.UserName;
            model.Password = um.Password;
            model.ConfirmPassword = um.ConfirmPassword;

            return model;
        }
    }
}