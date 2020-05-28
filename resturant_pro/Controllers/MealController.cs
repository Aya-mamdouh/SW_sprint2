using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using resturant_pro.Models;
using System.IO;

namespace resturant_pro.Controllers
{
    public class MealController : Controller
    {
        private DbModels db = new DbModels();

        // GET: Meal
        public ActionResult Index(string searching)
        {
            var Meals = db.Meals.Where(s => s.Name.Contains(searching) || searching == null).ToList();

            return View(Meals);
        }

        // GET: Meal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // GET: Meal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: Meal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Price,Description,Image ")] Meal meal, HttpPostedFileBase imgFile)
        {

            string path = "";
            
             if (imgFile.FileName.Length > 0)
            {
                path = "~/pics/" + Path.GetFileName(imgFile.FileName);
                imgFile.SaveAs(Server.MapPath(path));
            }
            meal.Image = path;

            //var before = db.Meals.AsNoTracking().Where(x => x.MealId == meal.MealId).ToList().FirstOrDefault();
            //meal.Name = before.Name;
            //meal.Price = before.Price;
            //meal.Description= before.Description;

            

                db.Entry(meal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

          
        }


        
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public int Count()
        {


            return db.Meals.ToList().Count();

        }






    }
}
