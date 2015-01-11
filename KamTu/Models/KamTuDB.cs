using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace KamTu.Models
{
    public class KamTuDB :DbContext
    {
        public DbSet<Person> Persons { set; get; }
        public DbSet<Driver> Drivers { set; get; }
        public DbSet<Pedestrian> Pedestrians { set; get; }
        public DbSet<Community> Communitys { set; get; }
    }
}