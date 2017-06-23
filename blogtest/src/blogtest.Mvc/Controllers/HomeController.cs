using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using IdentityModel.Client;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using blogtest.BLL;
using blogtest.BLL.Interfaces;
using blogtest.Mvc.Models;
using blogtest.Common.Dtos;

namespace blogtest.Mvc.Controllers
{
    public class HomeController : Controller  
    {

        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 3;   // количество элементов на странице

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


        [Authorize]
        public RedirectToRouteResult Secure()
        {
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            await HttpContext.Authentication.SignOutAsync("oidc");
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> CallApiUsingClientCredentials()
        {
            var tokenClient = new TokenClient("http://localhost:5000/connect/token", "mvc", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);
            var content = await client.GetStringAsync("http://localhost:5001/identity");

            ViewBag.Json = JArray.Parse(content).ToString();
            return View("json");
        }

        public async Task<IActionResult> CallApiUsingUserAccessToken()
        {
            var accessToken = await HttpContext.Authentication.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.SetBearerToken(accessToken);
            var content = await client.GetStringAsync("http://localhost:5001/identity");

            ViewBag.Json = JArray.Parse(content).ToString();
            return View("json");
        }
    }
}
