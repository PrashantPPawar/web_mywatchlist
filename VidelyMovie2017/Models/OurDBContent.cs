using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VidelyMovie2017.Models
{
    public class OurDBContent:DbContext
    {
        public DbSet<UserAccount> UserAccount { get; set; }
    }
}