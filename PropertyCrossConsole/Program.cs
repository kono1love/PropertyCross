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

using System.Configuration;

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
       
        [JsonProperty("img_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ImgUrl { get; set; }
      
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public int Price { get; set; }
     
        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }
        //public int thumb_height { get; set; }
        //public string thumb_url { get; set; }
        //public int thumb_width { get; set; }
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
        
    }

    public class Location
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
    }

    public class Response
    {
        [JsonProperty("listings", NullValueHandling = NullValueHandling.Ignore)]
        public List<Listing> Listings { get; set; }
        [JsonProperty("locations", NullValueHandling = NullValueHandling.Ignore)]
        public List<Location> Locations { get; set; }
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
            var flats = result.Response.Listings.Select(x => new Flat
            {
                Price = x.Price.ToString(),
                FlatLocation = x.Title.ToString(),
                BedNum = x.BedNum.ToString(),
                BathNum = x.BathNum.ToString(),
                Summary = x.Summary.ToString()

            });

            //ShowFlat(new Flat());

            using (var context = new FlatDbContext())
            {
                context.Flats.AddRange(flats);
                
                context.SaveChanges(); //context
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
