using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tacopajen.Database;
using Tacopajen.Models;

namespace Tacopajen.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            var dbcon = new Db();

            var recipes = dbcon.GetAllRecipe();
            var model = new RecipeViewModel();
            
            var ingredients = new  List<List<Ingredient>>();
            foreach (var recipe in recipes)
            {
                var ingredientsForRecipe = dbcon.GetAllIngredientsfor(Guid.Parse(recipe.Id));
                
                ingredients.Add(ingredientsForRecipe);
                
            }
            model.Ingredients = ingredients;
            model.Recipes = recipes;
            return View(model);
        }
    }
}