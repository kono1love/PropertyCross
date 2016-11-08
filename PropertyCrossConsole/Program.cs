using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Domain;

namespace PropertyCrossConsole
{
  public  class Program
    {
        static HttpClient Client = new HttpClient();
       
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36");
            RunAsync().Wait();
            var test = GetAsync(string.Empty).Result;
            Console.WriteLine($"Price - {test.Price}");
            Console.WriteLine($"Description - {test.Description}");
            Console.WriteLine($"Location - {test.FlatLocation}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static async Task<Flat> GetAsync(string path)
        {

            Flat flat = null;
            HttpResponseMessage response = await Client.GetAsync(@"http://api.nestoria.co.uk/api?country=uk&pretty=1&action=search_listings&encoding=json&listing_type=buy&page=1&place_name=leeds");
                if (response.IsSuccessStatusCode)
            {
                flat = await response.Content.ReadAsAsync<Flat>();
            }
            return flat;
        }
        static async Task RunAsync()
        {
            Client.BaseAddress = new Uri("http://api.nestoria.co.uk/api");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }
        
    }
}
