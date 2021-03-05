using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using PrjDay2.Models;

namespace PrjDay2.Controllers
{
    public class StoredProcController : Controller
    {
        NorthwindEntities db1 = new NorthwindEntities();
        // GET: StoredProc
        public ActionResult Index()
        {
            return View();
        }

        //1 Call procedure expensive product
        public ActionResult ExpensiveProduct()
        {
            return View(db1.Ten_Most_Expensive_Products());
        }

        //Viewing mutiple table details using navigation properties of the EDM
        public ActionResult CustOrdersInfo()
        {
            return View(db1.Orders.ToList());
        }
        //mutiple table details using expandoObject()
        public ActionResult ExpandoEg()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.CustomerList = db1.Customers.ToList();
            mymodel.OrdersList = db1.Orders.ToList();
            return View(mymodel);
        }
        //linq operations with 
        //ElementAt - returns element at a particular position, else throws error
        //ElementAtOrDefault - returns element at a position, else returns null
        //Fist - returns the First Element, if array is empty - then throws an error
        //FirstOrDefault - to handle the errors of the above situation
        //Likewise Last, LastOrDefault

        public ContentResult linqElements()
        {
            string[] words = {  };
            string[] words1 = {"Soumya" };
            string[] words2 = {"John","Joe","David" };
            var result = words2.SingleOrDefault();
           
            return Content(result);
        }
        
    }
}