using PrjDay1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrjDay1.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        //Normal Method that returns a string
        public string NormalMethod()
        {
            return "Hello All!";
        }

        //View Result 
        public ViewResult ViewMethod()
        {
           // ViewData["val"] = "understanding View Data";
            return View();
        }

        //content Result

        public ContentResult ContentMethod()
        {
            // return Content("Good Morning!!", "text/plain");
            return Content("<h1>Good Morning to all of You!!</h1>", "text/html");
        }

        //empty result not for display
        [NonAction]
        public EmptyResult EmptyMethod()
        {
            int amt = 5000;
            float increase = (amt * 3 * 2) / 100;
            return new EmptyResult();
        }

        //return a Json Object

        public JsonResult JsonMethod()
        {
            
            Employee e = new Employee();
            e.Id = 100;
            e.Age = 27;
            e.Name = "Sunil";
            return Json(e, JsonRequestBehavior.AllowGet);

        }

        public ContentResult DefLinq()
        {
            var employee = new List<Employee>
            {
                new Employee{Id=1,Age=20,Name="AA"},
            new Employee{Id=2,Age=25,Name="BB"},
            new Employee{Id=3,Age=26,Name="CC"}
            };
            
            var emp = employee.Where(x => x.Age < 25).Select(y => y.Name); // deffered Execution

            // new addition to the collection
            employee.Add(new Employee { Id = 4, Age = 23, Name = "DD" }); 
           
            //execution of the query takes place here(lazy loading) and so, all the values in the 
            //collection including additions will be considered and executed
            foreach(var e in emp)
            {
                Response.Write(e);

            }
            return Content("All good");
        }

        //immediate Execution of the above

        public ActionResult ImmLinq()
        {
            var employee = new List<Employee>
            {
                new Employee{Id=1,Age=20,Name="AA"},
            new Employee{Id=2,Age=25,Name="BB"},
            new Employee{Id=3,Age=26,Name="CC"}
            };
            //immediate execution of the query and results converted to a list (early loading)
            var emp = employee.Where(x => x.Age < 25).Select(y => y.Name).ToList(); 

            //new addition to the collection, but not considered, since the query is already
            //executed 
            employee.Add(new Employee { Id = 4, Age = 23, Name = "DD" });

            //Just Iteration and Display of results
            foreach (var e in emp)
            {
                Response.Write(e);

            }
            return Content("All good");
        }
        
    }
}