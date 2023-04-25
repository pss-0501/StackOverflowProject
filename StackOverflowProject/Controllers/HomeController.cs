﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverflowProject.ServiceLayer;
using StackOverflowProject.ViewModels;

namespace StackOverflowProject.Controllers
{
    public class HomeController : Controller
    {
        IQuestionsService qs;
        ICategoriesService cs;

        public HomeController(IQuestionsService qs, ICategoriesService cs)
        {
            this.qs = qs;
            this.cs = cs;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<QuestionViewModel> questions = this.qs.GetQuestions().ToList();

            return View(questions);
        }

        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return View();
        }
    }
}