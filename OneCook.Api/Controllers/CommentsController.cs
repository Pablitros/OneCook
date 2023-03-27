using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneCook.BL.Services.Interfaces;
using OneCook.DL.VM.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OneCook.Api.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentServiceBL _commentService;


        public CommentsController(ICommentServiceBL commentService)
        {
            _commentService = commentService;
        }


        /// <summary>
        /// Gets all the comments from the recipe by recipe id
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpGet("/api/recipes/{recipeId}/comments")]
        public ActionResult<List<CommentVM>> GetCommentsFromRecipe(int recipeId)
        {
            return Ok(_commentService.GetCommentsFromRecipe(recipeId));
        }


        /// <summary>
        /// Post a comment on the recipe
        /// </summary>
        /// <param name="commentVM"></param>
        /// <returns></returns>
        [HttpPost("/api/recipes/comments")]
        public ActionResult PostComment([FromBody]CommentVM commentVM)
        {
            _commentService.PostComment(commentVM);
            return Ok();
        }

    }
}
