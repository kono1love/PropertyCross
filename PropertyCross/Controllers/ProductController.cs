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
        private FlatRepository repository;

        public ProductController(FlatRepository productRepository)
        {
            this.repository = productRepository;
        }
        public PartialViewResult FlatList(Flat flat)
        {
            return PartialView(flat);
        }
    }
}