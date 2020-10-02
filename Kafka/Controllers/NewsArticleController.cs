using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Services;
using Kafka.Data;
using Kafka.Database;
using Kafka.Database.Entities;

namespace Kafka.Controllers
{
    public class NewsArticleController : Controller
    {
        /// <summary>
        ///     Get all posts as json
        /// </summary>
        /// <returns>Json array</returns>
        public JsonResult ListAsJson()
        {
            return Json(NewsArticleManager.List(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewsArticles()
        {
            return View();
        }

        public ActionResult CreateNewsArticle()
        {
            return View();
        }

        [WebMethod]
        [ValidateInput(false)]
        public ActionResult UpdateArticle(FormCollection form)

        {
            var article = form["id"] == null 
                ? new NewsArticle() 
                : NewsArticleManager.Get(int.Parse(form["id"]));

            article.Title = form["newsArticleTitle"];
            article.Preamble = form["newsArticlePreamble"];
            article.Image = form["newsArticleImage"];
            article.Date = DateTime.Parse(form["newsArticleDate"]);
            article.Category = form["newsArticleCategory"];

            article = NewsArticleManager.UpdateOrCreate(article);

            return RedirectToAction("NewsArticles", "NewsArticle", article);
        }

        /// <summary>
        /// Edit 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View with input and text areas populated</returns>
        public ActionResult EditNewsArticle(int id)
        {
            /*if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/

            var model = NewsArticleManager.Get(id);
            return View(model);

        }
        /// <summary>
        /// Deletes article by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteArticle(int id)
        {
            NewsArticleManager.Delete(id);
            return RedirectToAction("NewsArticles", "NewsArticle");
        }
    }
}