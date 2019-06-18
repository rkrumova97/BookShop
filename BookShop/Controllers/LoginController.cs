﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BookShop.Data;
using BookShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class LoginController : Controller
    {
        BookShopDbContext _db;
        public LoginController(BookShopDbContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
                    using (_db)
                    {
                        var obj = _db.Users.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                        if (obj != null)
                        {
                        HttpContext.Session.SetString("Id", obj.Id.ToString());
                        HttpContext.Session.SetString("Username", obj.Username.ToString());
                        HttpContext.Session.SetString("Name", obj.Name.ToString());

                    ViewBag.ErrorMessage = "UserName or Password is wrong";
                    return Redirect("/home/index");
                        }
                    }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}