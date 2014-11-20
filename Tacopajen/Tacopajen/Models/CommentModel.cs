using System.Collections.Generic;

namespace Tacopajen.Models
{
    public class CommentModel
    {
        public List<Comment> Comments { get; set; }
        public string RecipeId { get; set; }
    }
}