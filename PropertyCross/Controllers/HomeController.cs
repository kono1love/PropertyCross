using System.Linq;
using System.Web.Mvc;
using DataAccess;
using Domain;
using NestoriaClient;
using PropertyCross.Models;


namespace PropertyCross.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult 
        public ActionResult Index()
        {

            return View(new ListingFiltersViewModel(ListingTypes.Buy));
        }

        [HttpPost]
        public ActionResult ListingFilters (ListingFiltersRequestModel model)
            {
                var client = new Client();
                var listings =
                    client.RunAsync(new ListingAction(new ListingFilters(model.Type, model.PlaceName))).Result;
                var flats = listings.Response.Listings.Select(x => new Flat
                {
                    Price = x.Price.ToString(),
                    Title = x.Title,
                    ImgUrl = x.ImgUrl,
                    FlatLocation = x.Title,
                    BedNum = x.BedNum.ToString(),
                    BathNum = x.BathNum.ToString(),
                    Summary = x.Summary,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude

                });
                using (var context = new FlatDbContext())
                {
                    context.Flats.AddRange(flats);

                    context.SaveChanges();
                }

                return View("~/Views/NestoriaClient/List.cshtml", flats);
            }

        }

    }
           
        