using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_FAQ_BYUIS.Controllers
{
    public class AboutController : Controller
    {
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
        public ActionResult DegreeInfo(string degree)
        {
            ViewBag.statusDegrees = "active";

            //Dynamically return content based on degree
            if (degree == "MISM")
            {
                ViewBag.degreeAccronym = "MISM";
                ViewBag.degreeName = "Masters in Information Systems Management";
                ViewBag.CoordinatorName = "Bonnie Anderson";
                ViewBag.CoordinatorTitle = "<span><b>Associate Professor of Information Systems</b></span>,<br><span class=\"deptLink\"><a href=\"https://marriottschool.byu.edu/directory/departmental#dept-5\">Information Systems, Department of</a>";
                ViewBag.CoordinatorOfficeAddress = "776 TNRB";
                ViewBag.CoordinatorPhDEducation = "PhD, Information Systems, Carnegie Mellon University, 2001";
                ViewBag.CoordinatorMastersEducation = "MAcc, Information Systems, Brigham Young University, 1995";
                ViewBag.CoordinatorBachelorsEducation = "BS, Accounting, Brigham Young University, 1995";
                ViewBag.CoordinatorImage = "https://marriottschool.byu.edu/msmadmin/securefile/empphoto/?file=b0%2F1478.jpg";
            }
            else
            {
                ViewBag.degreeAccronym = "BSIS";
                ViewBag.degreeName = "Bachelor of Science in Information Systems";
                ViewBag.CoordinatorName = "Dr.Albrecht";
                ViewBag.CoordinatorTitle = "<span><b>Professor of Information Systems</b></span>,<br><span class=\"deptLink\"><a href=\"https://marriottschool.byu.edu/directory/departmental#dept-5\">Information Systems, Department of</a></span>";
                ViewBag.CoordinatorOfficeAddress = "780 TNRB";
                ViewBag.CoordinatorPhDEducation = "N/A";
                ViewBag.CoordinatorMastersEducation = "N/A";
                ViewBag.CoordinatorBachelorsEducation = "N/A";
                ViewBag.CoordinatorImage = "https://marriottschool.byu.edu/msmadmin/securefile/empphoto/?file=b0%2F5293.jpg";
            }

            string name = degree;

            ViewBag.BreadCrumb = BreadCrumb(name, "Degrees", "Degrees");

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