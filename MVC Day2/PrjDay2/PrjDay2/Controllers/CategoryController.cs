using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrjDay2.Models;

namespace PrjDay2.Controllers
{
    public class CategoryController : Controller
    {
        //1
        NorthwindEntities db = new NorthwindEntities();
        // GET: Category
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("GetCategoryScaffolded");
        }

        //2 Fetch Data from category table
        public ActionResult GetCategoryDetails()
        {                      
                                      //converting to list 
            List<Category> cat1 = db.Categories.ToList();
            return View(cat1);
        }

        //3 fetching data by category name ascending
        //linq query
        public ActionResult GetCategoryByName()
        {
            //query syntax
            List<string> c = (from cat in db.Categories
                              orderby cat.CategoryName
                              select cat.CategoryName).ToList();
            return View(c);

            
        }
        //3 Method Syntax
        public ActionResult GetCategoryMethod()
        {
            dynamic c = (db.Categories.OrderBy(ca => ca.CategoryName).Select(c1 => c1.CategoryName)).ToList();
            return View(c);
        }

        //4 Getting Category details by scaffolding the view
        public ActionResult GetCategoryScaffolded()
        {
            List<Category> cat = db.Categories.ToList();
            return View(cat);
        }
        //5 Crud Operations involving get of create and post of create
      [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

      [HttpPost]
        public ActionResult Create(Category cat)
        {
            db.Categories.Add(cat);
            db.SaveChanges();
            return RedirectToAction("GetCategoryScaffolded");
        }

        public ActionResult Details(int id)
        {
            Category c = db.Categories.Find(id);
            return View(c);
        }

        //deleting a record
        public ActionResult Delete(int id)
        {
            Category c = db.Categories.Find(id);
            db.Categories.Remove(c);
            db.SaveChanges();
            return RedirectToAction("GetCategoryScaffolded");
        }

        //editing records
        public ActionResult Edit(int id)
        {
            Category cat = db.Categories.Find(id);
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            Category c = db.Categories.Find(category.CategoryID);
            c.CategoryName = category.CategoryName;
            c.Description = category.Description;
            db.SaveChanges();
            return RedirectToAction("GetCategoryScaffolded");
        }

    }
}