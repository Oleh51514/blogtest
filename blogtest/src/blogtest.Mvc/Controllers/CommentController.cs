using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blogtest.BLL.Interfaces;
using blogtest.Common.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace blogtest.Mvc.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        // GET: /<controller>/
        public async Task<IActionResult> GetCommentList(CommentDto model)
        {
            model.DateTime = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                _commentService.Create(model);
            }
            
            var source = await _commentService.GetAllAsync(model.PostId);
            return PartialView(source);
        }
    }
}
