using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrjDay3.Models;

namespace PrjDay3.Controllers
{
    public class CarController : Controller
    {
        CarContext cc = new CarContext();
        Car c = new Car();
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }

        //creating car object or inserting into car
        public ActionResult Create()
        {
            return View(c);
        }

        [HttpPost]
        public ActionResult Create(Car car)
        {
            cc.cars.Add(car);
            cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}