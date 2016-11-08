using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataAccess
{
    internal class Context : DbContext
    {
        public DbSet<Flat> Flats { get; set; }
    }
}
