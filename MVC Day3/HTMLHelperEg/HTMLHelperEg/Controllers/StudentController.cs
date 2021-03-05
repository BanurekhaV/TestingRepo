using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTMLHelperEg.Models;

namespace HTMLHelperEg.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        //stringly typed Helper
        public ActionResult StronglyTypedCreate()
        {
            return View();
        }

        //templated helper
        public ActionResult TemplatedHelper()
        {
            return View();
        }

        //templated Helper 2 (ModelFor)
        public ActionResult EditorFormodel()
        {
            return View();

        }
        //Retrieving data through request object
        public ActionResult Create()
        {
            return View(); 
        }
             
       // [HttpPost,ActionName("Create")]
        /*public ActionResult CreatePost()
        {
            Student s = new Student();
            s.RollNo = Convert.ToInt32(Request["RollNo"]);
            s.Name = Request["Name"].ToString();
            s.City = Request["City"].ToString();
            return View(s);

        }*/

        //retrieving data through parameters
        [HttpPost,ActionName("Create")]
        public ActionResult CreatePost(string name, string city, string gender, string address)
        {
            Student s = new Student();
            s.Name = name;
            s.City = city;
            s.Gender = gender;
            s.Address = address;
            TempData["student"] = s;
            TempData.Keep();
            return RedirectToAction("Index");
           

        }
        


    }

}