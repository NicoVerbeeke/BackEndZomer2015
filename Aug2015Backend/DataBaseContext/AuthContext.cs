using Aug2015Backend.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataBaseContext
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("name=AuthContext")
        {
            
        }

        //public virtual DbSet<AspNetUsers> AuthUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // the all important base class call! Add this line to make your problems go away.
            base.OnModelCreating(modelBuilder);
        }
    }
}