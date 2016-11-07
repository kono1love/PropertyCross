using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PropertyCross.Models
{
    public class FlatContext : DbContext
    {
        public  DbSet<Flat> Flats { get; set; }
    }
}