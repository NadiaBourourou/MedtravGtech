using Data.Models;
using PagedList;
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
        int userId=1;
        

        public TestimonyController(ITestimonyService testimonyService)
        {
            this.testimonyService = testimonyService;
        }

        // GET: Testimony
        public ActionResult Index(int? page)
        {
            var allTestimonies = testimonyService.getAllTestimonies();
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = allTestimonies.ToPagedList(pageNumber, 4); // will only contain 4 testimonies max because of the pageSize

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View(allTestimonies.ToPagedList(pageNumber, 4));
            
        }

        // GET: Testimony/Details/5
        public ActionResult Details(int id)
        {
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
        public ActionResult Create(t_testimony t)
        {

            if (ModelState.IsValid)
            {
                t.date = DateTime.Now;
                t.patient_userId =userId;

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
        //int id, FormCollection collection
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
