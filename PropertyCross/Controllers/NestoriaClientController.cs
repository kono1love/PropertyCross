using System.Web.Mvc;
using NestoriaClient;

namespace PropertyCross.Controllers
{
    public class NestoriaClientController : Controller
    {
        public ActionResult ListingFilters()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListingFilters(ListingAction model)
        {
            var test = string.Empty;
            return View();
        }

    }
}