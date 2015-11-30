using Data.Infrastructure;
using Data.Models;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class MedicalRecordsController : Controller
    {
        public UnitOfWork unitOfWork = new UnitOfWork();

        IMedicalRecordsService ause;
        public MedicalRecordsController(IMedicalRecordsService ause)
        {
            this.ause = ause;
        }
        // GET: MedicalRecords
        public ActionResult Index()
        {
            var l = ause.getAllMedicalRecords();
            return View(l);
        }

        // GET: MedicalRecords/Details/5
        public ActionResult Details(int id)
        {
            t_medicalrecords m = ause.GetById(id);

            return View(m);
        }

        // GET: MedicalRecords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalRecords/Create
        [HttpPost]
        public ActionResult Create(t_medicalrecords a, HttpPostedFileBase fileId)
        {
            if (ModelState.IsValid) {
                if (fileId != null)
                {
                    fileId.SaveAs(HttpContext.Server.MapPath("~/Upload/")
                                                          + fileId.FileName);
                    a.fileAnalysis = fileId.FileName;
                    //
                   
                }

               ause.AddMedicalRecords(a);
            //    var path = Path.Combine(Server.MapPath("~/Upload/"), ImageId.FileName);
            //    ImageId.SaveAs(path);
               return RedirectToAction("Index");
            }
            else
            {
                return View();
           }
        }

        // GET: MedicalRecords/Edit/5
        public ActionResult Edit(int id)
        {
            t_medicalrecords medicalRecords = ause.GetById(id);
            return View(medicalRecords);
        }

        // POST: MedicalRecords/Edit/5
        [HttpPost]
        public ActionResult Edit(t_medicalrecords m)
        {
            if (ModelState.IsValid)
            {

                ause.UpdateMedicalRecords(m);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: MedicalRecords/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicalRecords/Delete/5
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

        [HttpGet]
        public ActionResult ShowFile(int id)
        {
            var m = ause.GetById(id);
            string filename = m.fileAnalysis;
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Upload/" + filename;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }
    }
}
