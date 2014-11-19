using System.Web.Mvc;
using Tacopajen.Models;

namespace Tacopajen.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Comments()
        {
            ViewBag.Message = "Your application description page.";

            return View(new CommentModel());
        }

    }
}