using System.Collections.Generic;

namespace Tacopajen.Models
{
    public class RecipeViewModel
    {
        public Recipe Recipe { get; set; }
        public TotalIngredients Ingredients { get; set; }
        public IEnumerable<Recipe> OtheRecipes { get; set; } 
    }
}