using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreBlogDataLibrary;

namespace WebBlog.Controllers
{
    public class AuthorController : Controller
    {
        private static AuthorRepository _authorRepo = new AuthorRepository();

        // GET: Author
        public ActionResult Index()
        {
            return View(_authorRepo.List());
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View(_authorRepo.GetById(id));
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author newAuthor, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _authorRepo.Add(newAuthor);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(newAuthor);
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Author/Edit/5
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

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Author/Delete/5
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