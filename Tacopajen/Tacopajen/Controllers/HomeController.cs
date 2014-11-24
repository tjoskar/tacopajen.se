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
            ViewBag.Title = "För alla som älskar tacopaj!";
            var dbcon = new Db();
            var recipe = dbcon.GetRecipe("tacopaj");
            var model = new RecipeViewModel
            {
                OtheRecipes = dbcon.GetAllRecipe(),
                Recipe = recipe,
                Ingredients = dbcon.GetAllIngredients(Guid.Parse(recipe.Id)),
                Comments = new CommentModel() { Comments = dbcon.GetCommentsByRecipe(Guid.Parse(recipe.Id)), RecipeId = recipe.Id },
                Rating = dbcon.GetRating(Guid.Parse(recipe.Id)),
                RatingCount = dbcon.GetRatingCount(Guid.Parse(recipe.Id))
            };


            return View(model);
        }

    }
}
