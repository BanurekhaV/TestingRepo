using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HTMLHelperEg.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        //standard html Helpers
        public ActionResult CreateRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRegistration(FormCollection frm)
        {
            string name = frm["txtName"].ToString();
            string password = frm["txtPwd"].ToString();
            string gender = frm["Gender"].ToString();
            bool cooking = Convert.ToBoolean(frm["C"].Split(',')[0]);
            bool sports = Convert.ToBoolean(frm["S"].Split(',')[0]);
            bool arts = Convert.ToBoolean(frm["A"].Split(',')[0]);
            string interest="";
            if (cooking == true)
                interest += "Cooking";
            if (sports == true)
                interest += "Sports";
            if (arts == true)
                interest += "Arts";
            string city = frm["City"].ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append(name + "</br>");
            sb.Append(password + "</br>");
            sb.Append(gender + "</br>");
            sb.Append(interest + "</br>");
            sb.Append(city);
                    
            return Content(sb.ToString());
        }

    }
}