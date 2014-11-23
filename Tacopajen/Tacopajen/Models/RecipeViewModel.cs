using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;

namespace Tacopajen.Models
{
    public class RecipeViewModel
    {
        public Recipe Recipe { get; set; }
        public TotalIngredients Ingredients { get; set; }
        public IEnumerable<Recipe> OtheRecipes { get; set; }
        public CommentModel Comments { get; set; }
    }
}