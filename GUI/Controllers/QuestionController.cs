using Data.Models;
using GUI.Models;
using Newtonsoft.Json;
using PagedList;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class QuestionController : Controller
    {

        IQuestionService questionService;
        int connectedUserId = 1;

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

       
        // GET: Question
        public ActionResult Index(int? page, string optionChoisie = "", string searchTextBox = "")
        {
            
            ViewBag.connectedUserId = connectedUserId;
             var allQuestions = questionService.getAllQuestions();
          
            if (optionChoisie == "Title")
            {
                allQuestions = allQuestions.Where(s => s.title.ToLower().Contains(searchTextBox.ToLower()) || searchTextBox == null).ToList();
            }
            else
            {
                allQuestions = allQuestions.Where(s => s.description.ToLower().Contains(searchTextBox.ToLower()) || searchTextBox == null).ToList();
            }

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = allQuestions.ToPagedList(pageNumber, 4); // will only contain 4 testimonies max because of the pageSize

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View(allQuestions.ToPagedList(pageNumber, 4));
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.connectedUserId = connectedUserId;
            t_question question = questionService.GetById(id);

            return View(question);
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(t_question t )
        {
            if (ModelState.IsValid)
            {
                t.date = DateTime.Now;
                t.patient_userId =  connectedUserId;

                questionService.AddQuestion(t);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            t_question question = questionService.GetById(id);
            return View(question);
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(t_question question)
        {
            

            if (ModelState.IsValid)
            { 
                questionService.UpdateQuestion(question);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Question/Edit/5
        public ActionResult Answer(int id)
        {
            t_question question = questionService.GetById(id);
            return View(question);
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Answer(t_question question)
        {


            if (ModelState.IsValid)
            {
                questionService.UpdateQuestion(question);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        // GET: Question/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Please try again.";
            }

            t_question question = questionService.GetById(id);
            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                t_question question = questionService.GetById(id);
                questionService.DeleteQuestion(question);


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



        public PartialViewResult GetLinks()
        {

            return PartialView();
        }


        public ActionResult Chat()
        {
            return View();
        }

    }
}
