//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aug2015Backend.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContactInformation
    {
        public int Id { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
    
        public virtual Vacation Vacation { get; set; }
    }
}
