using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataAccess
{
    public class FlatContext : DbContext
    {
        public FlatContext()
        : base("name=FlatDB")

    {}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
        public DbSet<Flat> Flats { get; set; }
    }
   

  
}
