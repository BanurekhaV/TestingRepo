using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrjDay2.Models;

namespace PrjDay2.Controllers
{
    public class DefaultController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(int regid,string desc)
        {
            Region r = new Region();
            r.RegionID = regid;
            r.RegionDescription = desc;
            db.Regions.Add(r);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}