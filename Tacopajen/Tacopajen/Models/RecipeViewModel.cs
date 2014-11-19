using System.Collections.Generic;

namespace Tacopajen.Models
{
    public class RecipeViewModel
    {
        public Recipe Recipe { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public IEnumerable<Recipe> OtheRecipes { get; set; } 
    }
}