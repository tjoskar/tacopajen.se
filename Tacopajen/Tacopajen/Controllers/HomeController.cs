using System;
using System.Linq;
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
            var rnd = new Random();
            var model = new RecipeViewModel
            {
                OtheRecipes = dbcon.GetAllRecipe().ToList().OrderBy(x => rnd.Next()).Take(4),
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
