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
    
    public partial class Price
    {
        public int Id { get; set; }
        public double BasePrice { get; set; }
        public double SingleStarPrice { get; set; }
        public double DoubleStarPrice { get; set; }
    
        public virtual Vacation Vacation { get; set; }
    }
}
