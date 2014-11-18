using System.ComponentModel.DataAnnotations;

namespace Tacopajen.Models
{
    public class CommentModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}