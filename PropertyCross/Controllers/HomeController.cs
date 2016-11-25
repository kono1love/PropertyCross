using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
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
    }
}