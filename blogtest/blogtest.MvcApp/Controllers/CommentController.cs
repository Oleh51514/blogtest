using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blogtest.BLL.Interfaces;
using blogtest.Entities.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace blogtest.MvcApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;

        public CommentController(IPostService postService, ICommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }
        // GET: /<controller>/
        public IActionResult GetCommentList(Comment model, string postId)
        {
           
            //model.CreateDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                _commentService.Create(model, postId);
            }

            var source = _commentService.GetAllByPostId(model.Post.Id);
            return PartialView(source);
        }
    }
}
