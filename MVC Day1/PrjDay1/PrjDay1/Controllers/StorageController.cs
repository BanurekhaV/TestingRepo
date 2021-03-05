using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrjDay1.Controllers
{
    public class StorageController : Controller
    {
        // GET: Storage
        public ActionResult Index()
        {
            return View();
        }
        //1 using viewbag and viewdata
        public ActionResult Rules()
        {
            List<string> rule = new List<string>()
            { "Avoid T-Shirt","Carry your ID Card","Be onTime"};
            //viewbag
            ViewBag.ruledetails = rule;

            //ViewData
            ViewData["followrules"] = rule;
            return View();
        }

        //to check for the values of Viewbag/ViewData across requests
        //we find the data not retained
        public ActionResult TestData()
        {
            ViewBag.checkdata = "Viewbag data";
            return RedirectToAction("ViewMethod", "Demo");
        }

        //to retain the data acroos request using tempdata
        public ActionResult FirstRequest()
        {
            List<string> tempdataval = new List<string>();
            tempdataval.Add("Arjun");
            tempdataval.Add("Yudhister");
            tempdataval.Add("Bheem");
            tempdataval.Add("Nakul");
            tempdataval.Add("Sahadev");
            TempData["pandavs"] = tempdataval;
            //to retain the data for subsequent requests, use keep()
            TempData.Keep();
            return View();

        }

        public ActionResult SecondRequest()
        {
            List<string> str = TempData["pandavs"] as List<string>;
            return View(str);
        }
    }
}