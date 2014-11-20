using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tacopajen.Models
{
    public class CommentModel
    {
        public List<Comment> Comments { get; set; }
        public string RecipeId { get; set; }
    }
}