using System.Collections.Generic;

namespace Tacopajen.Models
{
    public class RecipeListViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; }
        public IEnumerable<IEnumerable<Ingredient>> Ingredients { get; set; }
    }
}