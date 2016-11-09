using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Domain;

namespace PropertyCrossConsole
{
    static class Program
    {
        static HttpClient httpClient = new HttpClient();
        static readonly string url = @"http://api.nestoria.co.uk/api?country=uk&pretty=1&action=search_listings&encoding=json&listing_type=buy&page=1&place_name=leeds";

        static void Main(string[] args)
        {
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            var response = httpClient.GetAsync(new Uri(url)).Result;

            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            var flat = ParseResponse(ParseResponse(content)["response"].ToString());

            //var res = JsonConvert.DeserializeObject<Dictionary<string, object>>(values["response"].ToString());
            //content = System.Web.Helpers.Json.Decode(content).ToString();
            //var flat = RunAsync().Result;
            //ShowData(flat);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static Dictionary<string, object> ParseResponse(string response)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
        }

        private static void ShowData(Flat flat)
        {
            
        }

         static async Task<Flat> GetAsync(string url)
        {
            var flat = new Flat();

            return flat;
        }
        static async Task<Flat> RunAsync()
        {
            return await GetAsync(url);
        }
    }
}
