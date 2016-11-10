using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Newtonsoft.Json.Serialization;
using Domain;
using DataAccess;

namespace PropertyCrossConsole
{
    public class Attribution
    {
        //public int ImgHeight { get; set; }
        [JsonProperty("img_url")]
        public string ImgUrl { get; set; }
        //public int ImgWidth { get; set; }
        //public string LinkToImg { get; set; }
    }

    public class Listing
    {
        [JsonProperty("bathroom_number", NullValueHandling = NullValueHandling.Ignore)]
        public int BathNum { get; set; }
        [JsonProperty("bedroom_number")]
        public int BedNum { get; set; }
        //public int car_spaces { get; set; }
        //public int commission { get; set; }
        //public int construction_year { get; set; }
        //public string datasource_name { get; set; }
        //public int img_height { get; set; }
        [JsonProperty("img_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ImgUrl { get; set; }
        //public int img_width { get; set; }
        
        //public string Keywords { get; set; }
        //public double latitude { get; set; }
        //public string lister_name { get; set; }
        //public string lister_url { get; set; }
        //public string listing_type { get; set; }
        //public int location_accuracy { get; set; }
        //public double longitude { get; set; }
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public int Price { get; set; }
        //public string price_currency { get; set; }
        //public string price_formatted { get; set; }
        //public int price_high { get; set; }
        //public int price_low { get; set; }
        //public string price_type { get; set; }
        //public string property_type { get; set; }
        //public int size { get; set; }
        //public string size_type { get; set; }
        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }
        //public int thumb_height { get; set; }
        //public string thumb_url { get; set; }
        //public int thumb_width { get; set; }
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
        //public int updated_in_days { get; set; }
        //public string updated_in_days_formatted { get; set; }
    }

    public class Location
    {
        //public double center_lat { get; set; }
        //public double center_long { get; set; }
        //public string long_title { get; set; }
        //public string place_name { get; set; }
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
    }

    public class Response
    {
        //public string application_response_code { get; set; }
        //public string application_response_text { get; set; }
        //  public Attribution Attribution { get; set; }
        //public string created_http { get; set; }
        //public int created_unix { get; set; }
        //public string link_to_url { get; set; }
        [JsonProperty("listings", NullValueHandling = NullValueHandling.Ignore)]
        public List<Listing> Listings { get; set; }
        [JsonProperty("locations", NullValueHandling = NullValueHandling.Ignore)]
        public List<Location> Locations { get; set; }
        //public int page { get; set; }
        //public string sort { get; set; }
        //public string status_code { get; set; }
        //public string status_text { get; set; }
        //[JsonProperty("thanks", NullValueHandling = NullValueHandling.Ignore)]
        //public string Thanks { get; set; }
        //public int total_pages { get; set; }
        //public int total_results { get; set; }
        //public string listing_type { get; set; }
    }
  

public class SearchListings
    {
      //  public Request request { get; set; }
        [JsonProperty("response")]
        public Response Response { get; set; }
    }
    static class Program
    {
        static readonly HttpClient httpClient = new HttpClient();
        static readonly string url = @"http://api.nestoria.co.uk/api?country=uk&pretty=1&action=search_listings&encoding=json&listing_type=buy&page=1&place_name=leeds";

        static void Main()
        {
            var result = RunAsync().Result;
            var flat = result.Response.Listings.Select(x => new Flat
            {
                Price = x.Price.ToString(),
                FlatLocation = x.Title.ToString(),
                BedNum = x.BedNum.ToString(),
                BathNum = x.BathNum.ToString(),
                Summary = x.Summary.ToString()

            });

            //ShowFlat(new Flat());

            using (var context = new FlatContext())
            {
                    context.Entry(flat).State = EntityState.Added;
                context.SaveChangesAsync(); //context
            }

                Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

       
        static async Task<SearchListings> GetFlatAsync()
        {
            var response = await httpClient.GetAsync(new Uri(url));


            return await response.Content.ReadAsAsync < SearchListings>();
        }


        static async Task<SearchListings> RunAsync()
        {
            httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(
                "Mozilla/5.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            return await GetFlatAsync();
        }


        private static Dictionary<string, object> ParseResponse(string response)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
        }

        private static void ShowData(Flat flat)
        {
            
        }

        private static async Task<Flat> GetAsync(string url)
        {
            var flat = new Flat();

            return flat;
        }
     
    }

}
