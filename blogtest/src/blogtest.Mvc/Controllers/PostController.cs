using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blogtest.Mvc.Models;
using blogtest.BLL.Interfaces;

using Microsoft.AspNetCore.Authorization;
using blogtest.Entities.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace blogtest.Mvc.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;

        public PostController(IPostService postService, ICommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }

        public async Task<IActionResult> GetPostList(int page = 1)
        {
            int pageSize = 3;   

            var source = await _postService.GetAllAsync();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize);

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Posts = items
            };
            return View(viewModel);
        }

        public async Task<IActionResult> GetPost(int postId)
        {
            
            Post postSource = await _postService.GetById(postId);
            var commentSource = await _commentService.GetAllAsync(postId);
            var model = new PostViewModel
            {
                Coments = commentSource,
                Post = postSource
            };

            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Manage()
        {
            var source = await _postService.GetAllAsync();
            return View(source);
        }
        [Authorize]
        public async Task<IActionResult> Create(int id = 0)
        {
            Post post = await _postService.GetById(id);
            if (post == null)
            {
                post = new Post();
            }
            return View(post);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Post model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            if (model.Id == 0)
            {
                model.CreateDate = System.DateTime.Now;
                await _postService.AddAsync(model);
            }
            else
            {
                var post = _postService.Update(model);
            }

            return RedirectToAction("Manage");
        }
        [Authorize]
        public IActionResult Delete(int PostId)
        {
            _postService.Remove(PostId);
            return RedirectToAction("Manage");
        }

    }
}
