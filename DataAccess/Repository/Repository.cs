using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataAccess.Repository
{
    public class Repository
    {
        private static Dictionary<int, Flat> data = new Dictionary<int, Flat>();

        public IEnumerable<Flat> Flats
        {
            get { return data.Values; }
        }
    }
}
