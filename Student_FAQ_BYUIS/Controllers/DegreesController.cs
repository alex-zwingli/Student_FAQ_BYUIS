using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student_FAQ_BYUIS.Models;
using Student_FAQ_BYUIS.DAL;

//this degree controller is designed to handle all the logic regarding the degree views. 
//everyone can access the degree controller, no authentication required

namespace Student_FAQ_BYUIS.Controllers
{
    public class DegreesController : Controller
    {

        DegreeContext db = new DegreeContext();

        // GET: Degrees
        public ActionResult Index()
        {
            //Creat dropdown list
            List<SelectListItem> degrees = new List<SelectListItem>();
            degrees.Add(new SelectListItem { Text = "BSIS", Value = "0", Selected = true });
            degrees.Add(new SelectListItem { Text = "MISM", Value = "1", Selected = false });
            ViewBag.DegreeNames = degrees;

            return View();
        }

        public ActionResult DegreeInfo(string degree)
        {
            int id;

            if (degree == "MISM")
            {
                ViewBag.degreeAccronym = "MISM";
                ViewBag.degreeName = "Masters in Information Systems Management";
                id = 2;
            }
            else
            {
                ViewBag.degreeAccronym = "BSIS";
                ViewBag.degreeName = "Bachelor of Science in Information Systems";
                id = 1;
            }

            DegreeCoordinatorQuestions DegreeInfo = new DegreeCoordinatorQuestions();

            DegreeInfo.Degrees = db.Degrees.Find(id);
            DegreeInfo.Coordinators = db.Coordinators.Find(DegreeInfo.Degrees.CoordinatorID);
            DegreeInfo.Questions.ToList();


            return View();
        }
    }
}