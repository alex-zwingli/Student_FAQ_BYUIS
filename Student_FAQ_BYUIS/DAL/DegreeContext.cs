using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Student_FAQ_BYUIS.Models;

namespace Student_FAQ_BYUIS.DAL
{
    public class DegreeContext : DbContext
    {
        public DegreeContext() : base("DegreeContext")
        {

        }

        public DbSet<Degrees> Degrees { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Coordinators> Coordinators { get; set; }
        public DbSet<Users> Users { get; set; }
    }


}