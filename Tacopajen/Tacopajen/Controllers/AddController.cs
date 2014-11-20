using System.Web.Mvc;
using Tacopajen.Database;
using Tacopajen.Models;

namespace Tacopajen.Controllers
{
    public class AddController : Controller
    {
        // GET: Add
        [HttpGet]
        public ActionResult Index()
        {
            return View(new AddRecipeModel());
        }

        [HttpPost]
        public ActionResult Index(AddRecipeModel model)
        {
            var dbcon = new Db();
            dbcon.AddRecipe(model);
            return null;
        }
    }
}