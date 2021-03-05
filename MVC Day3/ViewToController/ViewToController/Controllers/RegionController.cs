using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewToController.Models;

namespace ViewToController.Controllers
{
    
    public class RegionController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Region
        public ActionResult Index()
        {
            //List<Region> reg = new List<Region>();
           // reg = db.Regions.ToList();
            return View(db.Regions.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        //Binding View Data with the controller using Request Object
      /*  [HttpPost,ActionName("Create")]
        public ActionResult CreatePost()
        {
            Region r = new Region();
            r.RegionID = Convert.ToInt32(Request["RegionID"]);
            r.RegionDescription = Request["RegionDescription"].ToString();
            db.Regions.Add(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

            //Binding View Data with the controller using Parameters
        [HttpPost]
            public ActionResult Create(int RegionID,string RegionDescription)
        {
            Region r = new Region();
            r.RegionID = RegionID;
            r.RegionDescription = RegionDescription;
            db.Regions.Add(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}