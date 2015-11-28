using Data.Models;
using PagedList;
using Recaptcha;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class TestimonyController : Controller
    {
        ITestimonyService testimonyService;
        int connectedUserId=1;
        

        public TestimonyController(ITestimonyService testimonyService)
        {
            this.testimonyService = testimonyService;
        }

        // GET: Testimony
        public ActionResult Index(int? page,string optionChoisie="",string searchTextBox="")
        {
            ViewBag.connectedUserId=connectedUserId;
            var allTestimonies = testimonyService.getAllTestimonies();
           
            if (optionChoisie == "Title")
            {
               allTestimonies = allTestimonies.Where(s => s.title.Contains(searchTextBox) || searchTextBox == null).ToList();
            }
            else 
            {
                allTestimonies = allTestimonies.Where(s => s.description.Contains(searchTextBox) || searchTextBox == null).ToList();
            }
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = allTestimonies.ToPagedList(pageNumber, 4); // will only contain 4 testimonies max because of the pageSize


            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View(allTestimonies.ToPagedList(pageNumber, 4));
            
        }

        // GET: Testimony/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.connectedUserId = connectedUserId;
            t_testimony testimony = testimonyService.GetById(id);
            
            return View(testimony);
        }

        // GET: Testimony/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Testimony/Create
        [HttpPost]
        [RecaptchaControlMvc.CaptchaValidator]
        public ActionResult Create(t_testimony t, bool captchaValid, string captchaErrorMessage)
        {

            if (ModelState.IsValid)
            {
                if (!captchaValid)
                {
                    ModelState.AddModelError("recaptcha", captchaErrorMessage);
                    return View(t);
                }

                t.date = DateTime.Now;
                t.patient_userId =connectedUserId;

                testimonyService.AddTestimony(t);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Testimony/Edit/5
        public ActionResult Edit(int id)
        {
            t_testimony testimony = testimonyService.GetById(id);
            return View(testimony);
        }

        // POST: Testimony/Edit/5
        [HttpPost]
        public ActionResult Edit(t_testimony testimony)
        {

            if (ModelState.IsValid)
            {
                // t_testimony testimony = testimonyService.GetById(id);
                testimonyService.UpdateTestimony(testimony);
            
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Testimony/Delete/5
        public ActionResult Delete(int id ,bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Please try again.";
            }

            t_testimony testimony = testimonyService.GetById(id);
            return View(testimony);
        }

        // POST: Testimony/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                t_testimony testimony = testimonyService.GetById(id);
                testimonyService.DeleteTestimony(testimony);

                
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
        { "id", id },
        { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }


     


    }
}
