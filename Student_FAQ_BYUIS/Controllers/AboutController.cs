using Student_FAQ_BYUIS.DAL;
using Student_FAQ_BYUIS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Controller is designed to display information regarding the about information for the major

namespace Student_FAQ_BYUIS.Controllers
{
    public class AboutController : Controller
    {
        private DegreeContext db = new DegreeContext();

        string controller = "About";

        //Overloaded methods that generate bootstrap breadcrumb navigation
        public string BreadCrumb()
        {
            return "<ol class=\"breadcrumb\"><li><a href=\"/\">Home</a></li><li class=\"active\">" + controller + "</li></ol>";
        }

        public string BreadCrumb(string name)
        {
            return "<ol class=\"breadcrumb\"><li><a href=\"/\">Home</a></li><li><a href=\"/" + controller + "/Index/\">About</a></li><li class=\"active\">" + name + "</li></ol>";
        }

        public string BreadCrumb(string name, string parent, string parentAction)
        {
            return "<ol class=\"breadcrumb\"><li><a href=\"/\">Home</a></li><li><a href=\"/" + controller + "/Index/\">About</a></li><li><a href=\"/" + controller + "/" + parentAction + "/\">" + parent + "</a><li class=\"active\">" + name + "</li></ol>";
        }

        public ActionResult Index()
        {
            ViewBag.statusDegrees = "active";
            ViewBag.BreadCrumb = BreadCrumb();
            return View();
        }

        // Degrees Tab
        public ActionResult Degrees()
        {
            ViewBag.statusDegrees = "active";
            ViewBag.BreadCrumb = BreadCrumb("Degrees");
            return View();
        }

        public ActionResult Degree(string degree)
        {
            int id;

            ViewBag.statusDegrees = "active";

            //Dynamically return content based on degree
            if (degree == "MISM")
            {
                id = 2;
            }
            else
            {
                id = 1;
            }

            TempData["DegreeID"] = id;
            TempData["DegreeName"] = degree;

            // Fetch Model
            DegreeCoordinatorQuestions DegreeInfo = new DegreeCoordinatorQuestions();

            // Populate Model
            DegreeInfo.Degrees = db.Degrees.Find(id);
            DegreeInfo.Coordinators = db.Coordinators.Find(DegreeInfo.Degrees.CoordinatorID);

            return View(DegreeInfo);
        }

        [HttpGet]
        [Authorize]
        public ActionResult DegreeInfo(string degree)
        {

            int id;

            ViewBag.statusDegrees = "active";

            //Dynamically return content based on degree
            if (degree == "MISM")
            {
                id = 2;
            }
            else
            {
                id = 1;
            }

            TempData["DegreeID"] = id;
            TempData["DegreeName"] = degree;

            DegreeCoordinatorQuestions DegreeInfo = new DegreeCoordinatorQuestions();

            DegreeInfo.Degrees = db.Degrees.Find(id);
            DegreeInfo.Coordinators = db.Coordinators.Find(DegreeInfo.Degrees.CoordinatorID);
            DegreeInfo.Questions = db.Database.SqlQuery<Questions>("SELECT * FROM Question WHERE (Question.DegreeID = " + id + ");");

            string name = degree;

            ViewBag.BreadCrumb = BreadCrumb(name, "Degrees", "Degrees");

            return View(DegreeInfo);
        }
        [HttpPost]
        [Authorize]
        public ActionResult DegreeInfo(DegreeCoordinatorQuestions Model)
        {
            //Insert additional question information
            Model.Question.DegreeID = (int)TempData["DegreeID"];
            Users CurrentUser = db.Database.SqlQuery<Users>("SELECT * From Users WHERE (Email = '" + User.Identity.Name + "');").FirstOrDefault<Users>();
            Model.Question.UserID = CurrentUser.UserID;
            Model.Question.Answer = "This question has yet to be answered.";

            //Save new entry in Database
            db.Questions.Add(Model.Question);
            db.SaveChanges();

            return RedirectToAction("DegreeInfo", new { degree = TempData["DegreeName"] });
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdateAnswer([Bind(Include = "QuestionID,DegreeID,UserID,Question,Answer")] DegreeCoordinatorQuestions Model)
        {



            // Get current user
            Users CurrentUser = db.Database.SqlQuery<Users>("SELECT * From Users WHERE (Email = '" + User.Identity.Name + "');").FirstOrDefault<Users>();

            // Use SQL to update database

            db.Database.ExecuteSqlCommand("UPDATE Question SET Answer = '" + Model.Question.Answer + "' WHERE (QuestionID = " + Model.Question.QuestionID + ");");

            // Preserve TempData
            string DegreeName = (string)TempData["DegreeName"];
            TempData["DegreeName"] = DegreeName;

            return RedirectToAction("DegreeInfo", new { degree = DegreeName });
        }



        public ActionResult FAQ()
        {
            return View();
        }


        // BS Info Sys Tab
        public ActionResult BSInfoSys()
        {
            ViewBag.statusBSinfo = "active";
            ViewBag.BreadCrumb = BreadCrumb("BS Info Sys");
            return View();
        }
        public ActionResult Rankings()
        {
            ViewBag.statusBSinfo = "active";
            ViewBag.BreadCrumb = BreadCrumb("Rankings", "BS Info Sys", "BSInfoSys");
            return View();
        }
        public ActionResult Awards()
        {
            ViewBag.statusBSinfo = "active";
            ViewBag.BreadCrumb = BreadCrumb("Awards", "BS Info Sys", "BSInfoSys");
            return View();
        }
        public ActionResult MissionStatement()
        {
            ViewBag.statusBSinfo = "active";
            ViewBag.BreadCrumb = BreadCrumb("Mission Statement", "BS Info Sys", "BSInfoSys");
            return View();
        }

        // Academics Tab
        public ActionResult Academics()
        {
            ViewBag.statusAcademics = "active";
            ViewBag.BreadCrumb = BreadCrumb("Academics");
            return View();
        }
        public ActionResult AcademicOverview()
        {
            ViewBag.statusAcademics = "active";
            ViewBag.BreadCrumb = BreadCrumb("Academic Overview", "Academics", "Academics");
            return View();
        }

        public ActionResult Faculty()
        {
            ViewBag.statusAcademics = "active";
            ViewBag.BreadCrumb = BreadCrumb("Faculty", "Academics", "Academics");
            return View();
        }

        // Careers Tab
        public ActionResult Careers()
        {
            ViewBag.statusCareers = "active";
            ViewBag.BreadCrumb = BreadCrumb("Careers");
            return View();
        }
        public ActionResult CareersOverview()
        {
            ViewBag.statusCareers = "active";
            ViewBag.BreadCrumb = BreadCrumb("Careers Overview", "Careers", "Careers");
            return View();
        }

        public ActionResult Internships()
        {
            ViewBag.statusCareers = "active";
            ViewBag.BreadCrumb = BreadCrumb("Internships", "Careers", "Careers");
            return View();
        }
    }
}