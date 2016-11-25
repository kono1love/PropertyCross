using NestoriaClient;
namespace PropertyCross.Models
{
    public class ListingFiltersRequestModel
    {
        public ListingTypes Type { get; set;}
        public string PlaceName { get; set; }
    }
}