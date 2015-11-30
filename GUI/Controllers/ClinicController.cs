using Data.Infrastructure;
using Data.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class ClinicController : Controller
    {
        public UnitOfWork unitOfWork = new UnitOfWork();

        IClinicService ause;

        public ClinicController(IClinicService ause)
        {
            this.ause = ause;
        }
        // GET: Clinic
        public ActionResult Index()
        {
            var l = ause.getAllClinics();
            return View(l);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var all = ause.getAllClinics();

            if (!String.IsNullOrEmpty(search))
            {
                all = ause.GetClinicsByResearch(search);
            }

            return View(all);
        }

        // GET: Clinic/Details/5
        public ActionResult Details(int id)
        {
            var clinic= ause.GetById(id);
            return View(clinic);
        }

        // GET: Clinic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clinic/Create
        [HttpPost]
        public ActionResult Create(t_clinic a, HttpPostedFileBase ImageId)
        {
            if (ModelState.IsValid)
            {
                if (ImageId != null)
                {
                    ImageId.SaveAs(HttpContext.Server.MapPath("~/Upload/")
                                                          + ImageId.FileName);
                    a.ImgName = ImageId.FileName;
                    //

                }

                ause.AddClinic(a);
                //    var path = Path.Combine(Server.MapPath("~/Upload/"), ImageId.FileName);
                //    ImageId.SaveAs(path);



                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Clinic/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clinic/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clinic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clinic/Delete/5
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
    }
}
