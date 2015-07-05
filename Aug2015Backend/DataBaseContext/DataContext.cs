﻿using Aug2015Backend.Entities;
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

    }
}