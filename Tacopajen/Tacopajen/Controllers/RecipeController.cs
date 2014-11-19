﻿using System;
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
            var model = new RecipeListViewModel {Recipes = recipes};

            return View(model);
        }

        public ActionResult Recipe(string id)
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
    }
}