using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Domain.Abstract
{
   public interface IFlatRepository
    {
        IEnumerable<Flat> Flats { get; }
    }
}
