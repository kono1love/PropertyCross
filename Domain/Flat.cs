using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Flat
    {
        [Key]
        public  int FlatId { get; set; }
        public string FlatLocation { get; set; }
        public string Summary { get; set; }
        public string Price { get; set; }
        public string BedNum { get; set; }
        public string BathNum { get; set; }
    }
}
