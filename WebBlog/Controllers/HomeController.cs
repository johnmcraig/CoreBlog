using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBlog.Models;
using CoreBlogDataLibrary;

namespace WebBlog.Controllers
{
    public class HomeController : Controller
    {
        private static AuthorRepository _authorRepo = new AuthorRepository();
        private static PostRepository _postRepository = new PostRepository();

        public IActionResult Index()
        {
            return View(_postRepository.ListAll());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
