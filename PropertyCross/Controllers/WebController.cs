using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using PropertyCross.Models;

namespace PropertyCross.Controllers
{
    public class WebController : ApiController
    {
       static HttpClient client = new HttpClient();

        static async Task RunAsync()
        {
            client.BaseAddress=new Uri("http://api.nestoria.co.uk/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


       static async Task<Flat> GetFlatAsync(string path)
       {
           Flat flat = null;
            HttpResponseMessage response = await client.GetAsync(path);
           if (response.IsSuccessStatusCode)
           {
               flat = await response.Content.ReadAsAsync<Flat>();
           }
           return flat;
       }
    }
}
