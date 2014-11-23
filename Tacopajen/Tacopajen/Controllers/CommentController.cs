using System;
using System.Web.Mvc;
using Tacopajen.Database;
using Tacopajen.Models;

namespace Tacopajen.Controllers
{
    public class CommentController : Controller
    {
        [HttpPost, ValidateInput(false)]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(FormCollection form)
        {
            var comment = new Comment()
            {
                Name = form["name"],
                Text = form["text"],
                RecipeId = Guid.Parse(form["recipeId"]),
                Score = Convert.ToInt32(form["score"])
            };

            var dbcon = new Db();
            dbcon.AddComment(comment);

            return Redirect(form["callback"]);
        }

    }
}