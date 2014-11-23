using System;
using System.Web.Mvc;
using Tacopajen.Database;
using Tacopajen.Models;

namespace Tacopajen.Controllers
{
    public class ReceptController : Controller
    {
        private RecipeViewModel GetRecipeModel(string id)
        {
            var dbcon = new Db();
            return new RecipeViewModel
            {
                OtheRecipes = dbcon.GetAllRecipe(),
                Recipe = dbcon.GetRecipe(Guid.Parse(id)),
                Ingredients = dbcon.GetAllIngredients(Guid.Parse(id)),
                Comments = new CommentModel() { Comments = dbcon.GetCommentsByRecipe(Guid.Parse(id)), RecipeId = id }
            };
        }

        public ActionResult Index()
        {
            var dbcon = new Db();

            var recipes = dbcon.GetAllRecipe();
            var model = new RecipeListViewModel {Recipes = recipes};

            return View(model);
        }

        public ActionResult Lchf()
        {
            ViewBag.Title = "LCHF";
            return View(
                "../Home/Index",
                GetRecipeModel("FA8EFDED-3DEB-49BF-A4BE-8EC0A05BDA84")
            );
        }

        public ActionResult Vegetarisk()
        {
            ViewBag.Title = "Vegetarisk";
            return View(
                "../Home/Index",
                GetRecipeModel("FA8EFDED-3DEB-49BF-A4BE-8EC0A05BDA85")
            );
        }

        public ActionResult Kyckling()
        {
            ViewBag.Title = "Kyckling";
            return View(
                "../Home/Index",
                GetRecipeModel("FA8EFDED-3DEB-49BF-A4BE-8EC0A05BDA86")
            );
        }

        public ActionResult Recipe(string id)
        {
            var model = GetRecipeModel(id);
            ViewBag.Title = model.Recipe.Name;
            return View(
                "../Home/Index",
                model
            );
        }
    }
}