using System.Collections.Generic;

namespace Tacopajen.Models
{
    public class TotalIngredients
    {
        public IEnumerable<Ingredient> Deg { get; set; }
        public IEnumerable<Ingredient> Fyll { get; set; }
    }
}