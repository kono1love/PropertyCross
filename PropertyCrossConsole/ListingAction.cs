//using System;

//namespace PropertyCrossConsole
//{
//    public enum ListingTypes
//    {
//        Buy,
//        Rent,
//        Share
//    }

//    public class ListingFilters
//    {
//        private ListingTypes _listingType { get; set; }
//        private string _placeName { get; set; }

//        public string ListingType => Enum.GetName(typeof(ListingTypes), _listingType).ToLower();
//        public string PlaceName => _placeName.ToLower();

//        public ListingFilters(ListingTypes listingType, string placeName)
//        {
//            _listingType = listingType;
//            _placeName = placeName;
//        }
//    }

//    public class ListingAction
//    {
//        private readonly ListingFilters _filters;

//        public string ListingUrl => $"country=uk&pretty=1&action=search_listings&encoding=json&listing_type={_filters.ListingType}&page=1&place_name={_filters.PlaceName}";

//        public ListingAction(ListingFilters filters)
//        {
//            CheckConditions(filters);

//            _filters = filters;
//        }

//        private void CheckConditions(ListingFilters filters)
//        {
//            if (string.IsNullOrEmpty(filters.PlaceName))
//                throw new ArgumentException("Empty place name", nameof(filters));
//        }
//    }
//}
