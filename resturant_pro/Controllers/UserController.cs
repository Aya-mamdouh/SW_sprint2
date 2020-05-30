using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using resturant_pro.Models;
using System.Net;

namespace resturant_pro.Controllers
{
    public class UserController : Controller
    {

        private DbModels db = new DbModels();
        // GET: User
        [HttpGet]
        public ActionResult AddOrEdit (int id=0)
        {
            User userModel = new User();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(User userModel )
        {
            using (DbModels dbModel = new DbModels())
            {
                if(dbModel.Users.Any(x => x.UserName == userModel.UserName))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("AddOrEdit", userModel);
                }
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("AddOrEdit", new User());
        }


        //Login 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(User user)
        {
            using (DbModels dbModel = new DbModels())
            {
                var UserDetails = dbModel.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                if (UserDetails == null)
                {
                    user.LoginErrorMessege = "Wrong username or password";
                    return View("Login", user);
                }

                else if (UserDetails.UserName == "Admin" && UserDetails.Password == "Admin")
                {
                    return RedirectToAction("Admin", "Admin");
                }

                else
                {
                    Session["UserId"] = UserDetails.Id;
                    Session["UserName"] = UserDetails.UserName;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        
        // LogOut 
        public ActionResult LogOut()
        {
            //   int userID = (int)Session["UserId"];
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }
        //ShowUsers
        [HttpGet]
        public ActionResult Users(int id = 0)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Users.ToList());
            }
        }

    }
}