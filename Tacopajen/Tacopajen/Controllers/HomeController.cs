using System;
using System.Web.Mvc;
using Tacopajen.Database;
using Tacopajen.Models;

namespace Tacopajen.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            const string id = "FA8EFDED-3DEB-49BF-A4BE-8EC0A05BDA83";
            var dbcon = new Db();
            var model = new RecipeViewModel();

            model.OtheRecipes = dbcon.GetAllRecipe();
            model.Recipe = dbcon.GetRecipe(Guid.Parse(id));
            model.Ingredients = dbcon.GetAllIngredients(Guid.Parse(id));
            

            return View(model);
        }

        public ActionResult Comments()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}
