using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blogtest.BLL.Interfaces;
using blogtest.Entities.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace blogtest.Mvc.Controllers
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
        public async Task<IActionResult> GetCommentList(Comment model, int PostId)
        {
            var post = await _postService.GetById(PostId);
            //model.Post = post;

            //model.Post.CreateDate = post.CreateDate;
            //model.Post.Description = post.Description;
            //model.Post.Id = post.Id;
            //model.Post.NamePost = post.NamePost;

            model.Post = post;
            model.CreateDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                _commentService.Create(model);
            }
            
            var source = await _commentService.GetAllAsync(model.Post.Id);
            return PartialView(source);
        }
    }
}
