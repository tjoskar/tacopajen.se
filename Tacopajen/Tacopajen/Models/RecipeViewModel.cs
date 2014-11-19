using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tacopajen.Models
{
    public class RecipeViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; }
        public IEnumerable<IEnumerable<Ingredient>> Ingredients { get; set; }
    }
}