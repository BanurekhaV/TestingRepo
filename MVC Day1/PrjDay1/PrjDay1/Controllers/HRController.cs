using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrjDay1.Models;

namespace PrjDay1.Controllers
{
    public class HRController : Controller
    {
        
        //1
        public ActionResult DisplayEmployee()
        {
            Employee emp = new Employee();
            emp.Id = 101;
            emp.Age = 30;
            emp.Name = "Ravishankar";
            return View(emp);
        }

        //2 
        public ActionResult ListEmployees()
        {
            List<Employee> e = new List<Employee>();
            e.Add(new Employee { Id = 1001, Name = "Samuel", Age = 25 });
            e.Add(new Employee { Id = 1002, Name = "Ramesh", Age = 26 });
            e.Add(new Employee { Id = 1003, Name = "Adhil", Age = 30 });
            return View(e);
        }

        // GET: HR
        //3 caling another action method within index(one more action method) of the same controller
        public ActionResult Index()
        {
            List<Department> d = new List<Department>();
            d.Add(new Department { Did = 10, Dname = "IT" });
            d.Add(new Department { Did = 20, Dname = "Finance" });
            d.Add(new Department { Did = 30, Dname = "Admin" });
            d.Add(new Department { Did = 40, Dname = "HR" });

            return View("ListofDepts",d);
        }

        //4
        public ActionResult ListofDepts(Department dept)
        {
            return View(dept);
        }

        //5
        //calling action method of other controller
        //call contact method of Home controller

        //6 calling a view of another controller
        public ActionResult CallContact()
        {
            return View("~/Views/Home/Contact.cshtml");
        }

        //7 redirecting to action method of another controller
        public ActionResult ReMethod()
        {
            return RedirectToAction("ContentMethod", "Demo");//action methodname,controller name
        }
    }
}