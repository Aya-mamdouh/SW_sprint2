using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using resturant_pro.Models;

namespace resturant_pro.Controllers
{
    public class OrdersController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        
        public ActionResult order_now(int id)
        {
            OrderMeal order = new OrderMeal();
            order.MealId = id;
            order.UserId = (int)Session["UserId"];
            db.OrderMeals.Add(order);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}