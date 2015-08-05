using Aug2015Backend.Entities;
using Aug2015Backend.Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aug2015Backend.DataComponentAdapters.ModelToEntity
{
    class ContactInformationMTEAdapter
    {
        //private VacationMTEAdapter vacationAdapter = new VacationMTEAdapter();

        public ContactInformation MapData(ContactInformationModel contactInformationModel, int p)
        {
            ContactInformation ci = new ContactInformation();

            if (contactInformationModel != null)
            {
                ci.Id = contactInformationModel.Id;
                ci.Tel = contactInformationModel.Tel;
                ci.Email = contactInformationModel.Email;
                //ci.Vacation = vacationAdapter.getVacation(p);
            }

            return ci;
        }
    }
}
