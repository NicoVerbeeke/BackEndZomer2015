using Aug2015Backend.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aug2015Backend.DataBaseContext
{
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=Model1Container")
        {

        }

        public virtual DbSet<Vacation> Vacations { get; set; }
        public virtual DbSet<AgeRange> AgeRanges { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Period> When { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<IncludedItem> Included { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // the all important base class call! Add this line to make your problems go away.
            base.OnModelCreating(modelBuilder);
        }
    }
}