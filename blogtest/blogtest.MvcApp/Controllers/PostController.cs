using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blogtest.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using blogtest.Entities.Entities;
using blogtest.MvcApp.Models;
using Kendo.Mvc.UI;


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
              

        [HttpGet]
        public JsonResult GetAll()
        {
            var source = _postService.GetAll().Select(a => new Post
            {
                Id = a.Id,
                NamePost = a.NamePost,
                Description = a.Description,
                CreationDate = a.CreationDate,
                Comment = null
            }).ToList();


            return this.Json(source);
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
        [HttpGet]
        [Authorize]
        public IActionResult Delete(string id)
        {
            _postService.Remove(id);
            return RedirectToAction("Manage");
        }


    }
    public class Example
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Company { get; set; }
    }
}

