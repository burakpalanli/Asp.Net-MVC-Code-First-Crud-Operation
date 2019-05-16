using CodeFirstCrud.Models.Context;
using CodeFirstCrud.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstCrud.Controllers
{
    public class HomeController : Controller
    {
        ProjectContext db = new ProjectContext();
     
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Product item)
        {
            db.Products.Add(item);
            bool result = db.SaveChanges() > 0;
            if (result)
            {
                TempData["message"] = "Success";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
           
        }

        public ActionResult Update(int id)
        {
            return View(db.Products.Find(id));
        }

        [HttpPost]
        public ActionResult Update(Product item)
        {
            db.Entry(db.Products.Find(item.Id)).CurrentValues.SetValues(item);
            bool result = db.SaveChanges() > 0;
            if (result)
            {
                TempData["message"] = "Update";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
          
        }

        public ActionResult Delete(int id)
        {
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
           
            TempData["message"] = "Delete";
            return RedirectToAction("Index");
           
        }

    }
}