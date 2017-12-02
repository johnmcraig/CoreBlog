using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreBlogDataLibrary;
using Microsoft.AspNetCore.Authorization;

namespace WebBlog.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private PostRepository _postRepo = new PostRepository();
        private AuthorRepository _authorRepo = new AuthorRepository();

        // GET: Post
        public ActionResult Index()
        {
            var post = _postRepo.ListAll();
            return View(_postRepo.ListAll());
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View(_postRepo.GetById(id));
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            Post newPost = new Post
            {
                PostDate = DateTime.Now,
                EditDate = DateTime.Now,
                PublishDate = DateTime.Now,
                PostAuthor = _authorRepo.GetById(1)
            };
            return View(newPost);
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post newPost, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                newPost.PostAuthor = _authorRepo.GetById(newPost.PostAuthor.Id);

                if(ModelState.IsValid)
                {
                    _postRepo.Add(newPost);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(newPost);
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}