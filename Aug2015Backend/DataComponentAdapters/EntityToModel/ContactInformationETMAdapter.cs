using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataComponentAdapters.EntityToModel
{
    public class ContactInformationETMAdapter
    {
        public ContactInformationModel MapData(ContactInformation ci)
        {
            ContactInformationModel cim = new ContactInformationModel();

            cim.Id = ci.Id;
            cim.Tel = ci.Tel;
            cim.Email = ci.Email;
            cim.VacId = ci.Vacation.Id;

            return cim;
        }
    }
}