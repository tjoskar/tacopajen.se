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
            var recipe = dbcon.GetRecipe(id);
            return new RecipeViewModel
            {
                OtheRecipes = dbcon.GetAllRecipe(),
                Recipe = recipe,
                Ingredients = dbcon.GetAllIngredients(Guid.Parse(recipe.Id)),
                Comments = new CommentModel() { Comments = dbcon.GetCommentsByRecipe(Guid.Parse(recipe.Id)), RecipeId = recipe.Id },
                Rating = dbcon.GetRating(Guid.Parse(recipe.Id)),
                RatingCount = dbcon.GetRatingCount(Guid.Parse(recipe.Id))
            };
        }

        public ActionResult Index()
        {
            var dbcon = new Db();

            var recipes = dbcon.GetAllRecipe();
            var model = new RecipeListViewModel {Recipes = recipes};

            return View(model);
        }

        public ActionResult Recipe(string groupName)
        {
            var model = GetRecipeModel(groupName);
            ViewBag.Title = model.Recipe.Name;
            return View(
                "../Home/Index",
                model
            );
        }
    }
}