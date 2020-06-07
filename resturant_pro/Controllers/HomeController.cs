using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using resturant_pro.Models;

namespace resturant_pro.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // GET: Home
        private DatabaseEntities db = new DatabaseEntities();
        public ActionResult Index(string searching)
        {
            var Meals = db.Meals.Where(s => s.Name.Contains(searching) || searching == null).ToList();

            return View(Meals);
        }
    }
}