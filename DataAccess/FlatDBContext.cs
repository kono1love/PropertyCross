using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataAccess
{
    public class FlatDbContext : DbContext
    {
        public FlatDbContext()
        : base("name=FlatDB")
        {}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flat>().ToTable("FlatDB");
        }
        public DbSet<Flat> Flats { get; set; }
    }
}
