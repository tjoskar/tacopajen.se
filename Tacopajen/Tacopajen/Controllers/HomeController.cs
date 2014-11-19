using System.Web.Mvc;
using Tacopajen.Models;

namespace Tacopajen.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(string id)
        {
            var dbcon = new Db();
            var model = new RecipeViewModel
            {
                OtheRecipes = dbcon.GetAllRecipe(),
                Recipe = dbcon.GetRecipe(Guid.Parse(id)),
                Ingredients = dbcon.GetAllIngredients(Guid.Parse(id))
            };

            return View(model);
        }

        public ActionResult Comments()
        {
            ViewBag.Message = "Your application description page.";

            return View(new CommentModel());
        }

    }
}
