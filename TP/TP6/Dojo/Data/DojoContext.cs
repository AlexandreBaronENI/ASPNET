﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dojo.Data
{
    public class DojoContext : DbContext
    {    
        public DojoContext() : base("name=DojoContext")
        {
        }

        public System.Data.Entity.DbSet<BO.Arme> Armes { get; set; }

        public System.Data.Entity.DbSet<BO.Samourai> Samourais { get; set; }
    }
}