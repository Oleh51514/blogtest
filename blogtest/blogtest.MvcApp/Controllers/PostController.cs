using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blogtest.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using blogtest.Entities.Entities;
using blogtest.MvcApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace blogtest.MvcApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
     

        public PostController(IPostService postService)
        {
            _postService = postService;

        }

        public IActionResult GetPostList(int page = 1)
        {
            int pageSize = 3;

            var source = _postService.GetAll();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize);

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexPostViewModel viewModel = new IndexPostViewModel
            {
                PageViewModel = pageViewModel,
                Posts = items
            };
            return View(viewModel);
        }

        public IActionResult GetPost(string postId)
        {

            Post postSource = _postService.GetById(postId);
            //var commentSource = await _commentService.GetAllAsync(postId);
            var model = new PostViewModel
            {
                Coments = postSource.Comment,
                Post = postSource
            };

            return View(model);
        }

        [Authorize]
        public IActionResult Manage()
        {
            var source = _postService.GetAll();
            return View(source);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create(string id)
        {
            if (id == null)
            {
                return View(new Post());
            }

            var post = _postService.GetById(id);
            return View(post);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Post model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //var post =_postService.GetById(model.Id);
            if (model.Id == null)
            {
                //model.CreationDate = System.DateTime.Now;
                _postService.Add(model);
            }
            else
            {
                _postService.Update(model);
            }

            return RedirectToAction("Manage");
        }

        [Authorize]
        public IActionResult Delete(string PostId)
        {
            _postService.Remove(PostId);
            return RedirectToAction("Manage");
        }

    }
}
