using System.Linq;
using System.Web.Mvc;
using Kafka.Data;

namespace Kafka.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsArticlesContext db = new NewsArticlesContext();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Items(int count)
        {
            return Json(db.NewsArticles, JsonRequestBehavior.AllowGet);
        }
    }
}