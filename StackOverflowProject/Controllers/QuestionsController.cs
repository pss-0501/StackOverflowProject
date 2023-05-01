using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverflowProject.ServiceLayer;
using StackOverflowProject.ViewModels;
using StackOverflowProject.DomainModels;

namespace StackOverflowProject.Controllers
{
    public class QuestionsController : Controller
    {
        IQuestionsService qs;
        IAnswersService ass;
        ICategoriesService cs;

        public QuestionsController(ICategoriesService cs, IAnswersService ass, IQuestionsService qs)
        {
            this.qs = qs;
            this.cs = cs;
            this.ass = ass;
        }

        // GET: Questions
        public ActionResult Views(int id)
        {
            this.qs.UpdateQuestionViewsCount(id, 1);
            int uid = Convert.ToInt32(Session["CurrentUserID"]);

            QuestionViewModel qvm = this.qs.GetQuestionByQuestionID(id, uid);

            if (qvm.CategoryID != 0)
            {
                using (var ctx = new StackOverflowDatabaseDbContext())
                {
                    var CategoryN = ctx.Categories.SqlQuery("Select * from Categories where CategoryID =" + id).FirstOrDefault();
                    ViewBag.CName = CategoryN.CategoryName;
                }
            }
            else
            {
                ViewBag.CName = "No Category";
            }

            if (qvm.AnswersCount != 0)
            { 
                using (var ctx = new StackOverflowDatabaseDbContext())
                {
                    var AnswerList = ctx.Answers.SqlQuery("Select * from Answers where QuestionID =" + id).ToList();
                    ViewBag.AnswerVote = AnswerList.Count;
                    //ViewBag.AnsUserID = AnswerList.UserID;
                    ViewBag.AnswerData = AnswerList.ToList();
                }
            }

            return View(qvm);
        }
    }
}