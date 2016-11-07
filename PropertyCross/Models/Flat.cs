using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyCross.Models
{
    public class Flat
    {
        public int FlatId { get; set; }
        public string FlatLocation { get; set; }
        public string Description { get; set; }
        public  string Price { get; set; }
        public bool IsEmpty { get; set; }
        
    }
}