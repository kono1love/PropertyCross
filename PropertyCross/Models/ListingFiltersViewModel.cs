using NestoriaClient;

namespace PropertyCross.Models
{
    public class ListingFiltersViewModel
    {
        public ListingTypes Type { get;  }
        public string PlaceName { get; set; }

        public ListingFiltersViewModel(ListingTypes type)
        {
            Type = type;
        }
    }
}