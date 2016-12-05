using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repository;
using Domain;

namespace PropertyCross.Controllers
{
    public class ProductController : Controller
    {
        public ViewResult FlatList(List<Flat> flat)
        {
            return View("List", flat);
        }
    }
}