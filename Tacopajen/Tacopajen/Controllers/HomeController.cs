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
            var model = new RecipeViewModel
            {
                OtheRecipes = dbcon.GetAllRecipe(),
                Recipe = dbcon.GetRecipe(Guid.Parse(id)),
                Ingredients = dbcon.GetAllIngredients(Guid.Parse(id)),
                Comments = new CommentModel(){ Comments = dbcon.GetCommentsByRecipe(Guid.Parse(id)), RecipeId = id}
            };


            return View(model);
        }

        public ActionResult Comments()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}
