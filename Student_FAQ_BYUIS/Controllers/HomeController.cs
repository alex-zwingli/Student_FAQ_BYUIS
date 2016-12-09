using Student_FAQ_BYUIS.DAL;
using Student_FAQ_BYUIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

//Home Controller
//This controller will have all the information regarding the home page

 //no authorization is needed for the home controller

namespace Student_FAQ_BYUIS.Controllers
{
    public class HomeController : Controller
    {
        DegreeContext db = new DegreeContext();

        public ActionResult Index()
        {
            //Create multidimensional ist to store quotes and autor seperately
            //hardcoding quotes
            string[] quotes = new string[2];
            List<string[]> quoteCatalog = new List<string[]>();
            quoteCatalog.Add(new string[2] {
                "There are no secrets to success. It is the result of preparation, hard work, and learning from failure.",
                "Colin Powell" });
            quoteCatalog.Add(new string[2] {
                "Our work is the presentation of our capabilities.",
                "Edward Gibbon" });
            quoteCatalog.Add(new string[2] {
                "Happiness does not come from doing easy work but from the afterglow of satisfaction that comes after the achievement of a difficult task that demanded our best.",
                "Theodore Isaac Rubin" });
            quoteCatalog.Add(new string[2] {
                "Happiness does not come from doing easy work but from the afterglow of satisfaction that comes after the achievement of a difficult task that demanded our best. ",
                "Theodore Isaac Rubin" });
            quoteCatalog.Add(new string[2] {
                "Ideas pull the trigger, but instinct loads the gun. ",
                "Don Marquis" });
            quoteCatalog.Add(new string[2] {
                "If you don't drive your business, you will be driven out of business. ",
                "B. C. Forbes" });
            quoteCatalog.Add(new string[2] {
                "Just because something doesn't do what you planned it to do doesn't mean it's useless. ",
                "Thomas A. Edison" });
            quoteCatalog.Add(new string[2] {
                "If you're trying to create a company, it's like baking a cake. You have to have all the ingredients in the right proportion. ",
                "Elon Musk" });
            quoteCatalog.Add(new string[2] {
                "People are definitely a company's greatest asset. It doesn't make any difference whether the product is cars or cosmetics. A company is only as good as the people it keeps. ",
                "Mary Kay Ash" });
            quoteCatalog.Add(new string[2] {
                "Rank does not confer privilege or give power. It imposes responsibility. ",
                "Peter Drucker" });
            quoteCatalog.Add(new string[2] {
                "Anyone who has lost track of time when using a computer knows the propensity to dream, the urge to make dreams come true and the tendency to miss lunch.",
                "Tim Berners-Lee" });
            quoteCatalog.Add(new string[2] {
                "A business that makes nothing but money is a poor business. Henry Ford",
                "Henry Ford" });

            //Randomly insert quote and author into viewbag. 
            Random rnd = new Random();
            int recall = rnd.Next(quoteCatalog.Count);
            ViewBag.quote = quoteCatalog[recall][0];
            ViewBag.author = quoteCatalog[recall][1];



            return View();
        }

        public ActionResult Contact()
        {
            //TextBox: User's Name
            ViewBag.Name = "Displayed in Name Box";

            //TextBox: Email
            ViewBag.Email = "someone@example.com";

            //CheckBox: Confirmation email
            ViewBag.ReceiveEmail = true;

            //DropDownList: Subject
            List<SelectListItem> subjects = new List<SelectListItem>();
            subjects.Add(new SelectListItem { Text = "Inquiring about BSIS", Value = "0", Selected = false });
            subjects.Add(new SelectListItem { Text = "Inquiring about MISM", Value = "1", Selected = false });
            subjects.Add(new SelectListItem { Text = "Application process", Value = "2", Selected = false });
            subjects.Add(new SelectListItem { Text = "Prerequisite advice", Value = "3", Selected = false });
            subjects.Add(new SelectListItem { Text = "Make an appointment", Value = "4", Selected = false });
            ViewBag.SubjectOptions = subjects;

            //TextArea: Message Body

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            //Ask about this...
            string Useremail = form["Email"].ToString();
            string Password = form["Password"].ToString();
            if (Useremail != null)
            {
                Users loginUser = db.Users.SingleOrDefault(user1 => user1.Email == Useremail && user1.Password == Password);
                if (loginUser != null)
                {
                    FormsAuthentication.SetAuthCookie(Useremail, rememberMe);
                    Session["Username"] = loginUser.Email;
                    //WHATEVER THIS NEEDS TO BE NAMED
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult RegisterOther()
        {
            return View();
        }
        //Post for new user, also logs the user in
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterOther(FormCollection form)
        {
            bool userAlreadyExists = false;
            string testEmail = form["email"].ToString();
            Users tempUser = db.Users.SingleOrDefault(user1 => user1.Email == testEmail);
            if (tempUser != null)
            {
                if (string.Equals(testEmail, tempUser.Email))
                {
                    userAlreadyExists = true;
                }
            }
            if (userAlreadyExists)
            {
                return View();
            }
            //Get data from form
            if (form["password"].ToString() == form["passwordToConfirm"].ToString())
            {
                string firstName = form["first_name"].ToString();
                string lastName = form["last_name"].ToString();
                string userNameEmail = form["email"].ToString();
                string password = form["password"].ToString();
                string password2 = form["passwordToConfirm"].ToString();
                Users temp = new Users { Email = userNameEmail, Password = password, FName = firstName, LName = lastName };
                //Add the user to the database
                db.Users.Add(temp);
                db.SaveChanges();
                //Log the user in
                bool rememberMe = false;
                FormsAuthentication.SetAuthCookie(userNameEmail, rememberMe);
                //Set session variable for later use
                Users loginUser = db.Users.SingleOrDefault(user1 => user1.Email == userNameEmail && user1.Email == password);
                Session["userID"] = loginUser.UserID;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        //register the user after the put the information in [Post]
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(FormCollection form)
        {
            bool contactExists = false;
            //checks if email already exists in emails to prevent duplicates
            try
            {
                string testEmail = form["Email"].ToString();
                Users tempUser = db.Users.SingleOrDefault(user1 => user1.Email == testEmail);
                if (string.Equals(testEmail, tempUser.Email))
                {
                    contactExists = true;
                }
            }
            catch
            {
                contactExists = false;
            }
            if (contactExists)
            {
                ViewBag.emailExists = "Sorry, that email is taken. Please choose another.";
                return View();
            }
            //gets all the data from the form
            if (form["Password"].ToString() == form["Password2"].ToString())
            {
                string firstname = form["Firstname"].ToString();
                string lastname = form["Lastname"].ToString();
                string usern = form["Email"].ToString();
                string password = form["Password"].ToString();
                string password2 = form["Password2"].ToString();
                Users temp = new Users { Email = usern, Password = password, FName = firstname, LName = lastname };
                //adds the user
                db.Users.Add(temp);
                db.SaveChanges();
                bool rememberMe = false;
                //logs in the person
                FormsAuthentication.SetAuthCookie(usern, rememberMe);
                Users tempUser = db.Users.SingleOrDefault(user1 => user1.Email == usern && user1.Password == password);
                //sets the session variable for use when they answer or post a question
                Session["userID"] = tempUser.UserID;
                //sendEmail(firstname + " " + lastname, usern);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View();
        }
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}