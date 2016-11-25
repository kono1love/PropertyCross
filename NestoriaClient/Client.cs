using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Newtonsoft.Json;

namespace NestoriaClient
{
    public class Client
    {
        readonly HttpClient httpClient = new HttpClient();
        readonly string baseUrl = @"http://api.nestoria.co.uk/api?";

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
            [JsonProperty("response")]
            public Response Response { get; set; }
        }

        public async Task<SearchListings> GetFlatAsync(ListingAction action)
        {
            var response = await httpClient.GetAsync(new Uri($"{baseUrl}{action.ListingUrl}"));
            return await response.Content.ReadAsAsync<SearchListings>();
        }

        public async Task<SearchListings> RunAsync(ListingAction action)
        {
            httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(
                "Mozilla/5.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            return await GetFlatAsync(action);
        }
        private static Dictionary<string, object> ParseResponse(string response)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
        }

        //private static async Task<Flat> GetAsync(string url)
        //{
        //    var flat = new Flat();

        //    return flat;
        //}
    }
}
