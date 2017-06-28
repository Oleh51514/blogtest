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
            var dataPage = _postService.GetDataPage(page, pageSize);
            PageViewModel pageViewModel = new PageViewModel(
                (int)dataPage.TotalItemCount,
                dataPage.PageNumber,
                dataPage.PageLength);
            IndexPostViewModel viewModel = new IndexPostViewModel
            {
                PageViewModel = pageViewModel,
                Posts = dataPage.Items
            };
            return View(viewModel);
        }

        public IActionResult GetPost(string postId)
        {
            Post postSource = _postService.GetById(postId);
            return View(postSource);
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

            if (model.Id == null)
            {
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
