using Data.Infrastructure;
using Data.Models;
using GUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


using Microsoft.Owin.Security;
using System.Web.UI;
using System.IO;
using System.Net.Mail;


namespace GUI.Controllers
{
    public class UserController : Controller
    {
        public UnitOfWork unitOfWork = new UnitOfWork();

        IUserService ause;
        public UserController(IUserService ause)
        {
            this.ause = ause;
        }


        // GET: User
        public ActionResult Index()
        {
            using (medtravdbContext entities = new medtravdbContext())
            {
           
                return View(entities.t_user.ToList());
            }
        }

        public ActionResult ListAllDoctors()
        {
            return View(ause.GetDoctors());
        } 

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "firstName, lastName, cin,login, mail,password,sexe,country,dateOfBirth,numPassport")] t_user U)
        {
            
            if (ModelState.IsValid)
            {
                ause.AddPatient(U);
                ModelState.Clear();
                ViewBag.Message = "Dear "+U.firstName+ ",<BR/>Please check your email.";

                var body = "Dear " + U.firstName + ", <BR/>Thank you for your registration, You can now login using these credentials : <BR/> Login : " + U.login + "<BR/> Password : " + U.password + ".";
                var message = new MailMessage();
                message.To.Add(new MailAddress(U.mail));  // replace with valid value 
                message.From = new MailAddress("medtrav.gtech@gmail.com");  // replace with valid value
                message.Subject = "Welcome to MedTrav";
                message.Body = string.Format(body, "MedTrav", "medtrav.gtech@gmail.com", body);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {

                    smtp.Send(message);
                   return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(t_user model)
        {
            var usr = ause.authenticate(model.login, model.password);

            if (usr != null)
            {
                Session["userId"] = usr.userId.ToString();
                Session["login"] = usr.login.ToString();
                Session["firstName"] = usr.firstName.ToString();
                Session["lastName"] = usr.lastName.ToString();
                Session["DTYPE"]= usr.DTYPE.ToString();

                FormsAuthentication.SetAuthCookie(model.login, false);
                if (usr.DTYPE == "Patient")
                { return RedirectToAction("PatientLoggedIn"); }
                if (usr.DTYPE == "Doctor")
                { return RedirectToAction("DoctorLoggedIn"); }
                if (usr.DTYPE == "Administrator")
                { return RedirectToAction("AdminLoggedIn"); }
            }

            else
                ModelState.AddModelError("", "Wrong credentials.");
            return View();

        }

        public ActionResult PatientLoggedIn()
        {
            if (Session["userId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Login");

        }

        public ActionResult AdminLoggedIn()
        {
            if (Session["userId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Login");

        }


        public ActionResult DoctorLoggedIn()
        {
            if (Session["userId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Login");

        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }



        // GET: User/Details/5
        public ActionResult AdminDisplaysDetailsDoctor(int id)
        {
            t_user u = ause.GetUserByID(id);
            return View(u);
        }

         // GET: User/Create
        public ActionResult AdminCreatesDoctor()
        {
            if (Session["userId"] != null )
            {
                return View();
            }
            else
                return RedirectToAction("Login");
        
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult AdminCreatesDoctor(t_user Doctor)
        {
        

              if (Session["userId"] != null)
            {
                ause.AddDoctor(Doctor);
                ModelState.Clear();
                ViewBag.Message = Doctor.login + " has successfully been added to our partners.";
                return RedirectToAction("AdminManageDoctors");
            }
            else
                return RedirectToAction("Login");

           
        }

        // GET: User/Edit/5
        public ActionResult AdminEditsDoctor(int id)
        {

            if (Session["userId"] != null && Session["DTYPE"].ToString() == "Administrator")
            {
                t_user user = ause.GetUserByID(id);
                return View(user);
            }
            else
                return RedirectToAction("Login");
                     
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult AdminEditsDoctor(int id, FormCollection collection)
        {
            try
            {
                ause.UpdateUser(ause.GetUserByID(id));
                return RedirectToAction("AdminManageDoctors");


            }
            catch
            {
                return View();

            }
        }



        public ActionResult AdminManageDoctors()
        {
            var doctors = ause.GetDoctors();
            return View(doctors);
        }




        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //public static Byte[] PdfSharpConvert(String html)
        //{
        //    Byte[] res = null;
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
        //        pdf.Save(ms);
        //        res = ms.ToArray();
        //    }
        //    return res;
        //}


    }
}