using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data.Repository;
using MyBlog.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyBlog.Controllers
{
    [Authorize(Roles ="admin")]
    public class PanelController : Controller
    {
        private readonly IRepository _repository;

        public PanelController(IRepository repository)
        {
            _repository = repository;
        }
       

        // GET: /<controller>/
        public IActionResult Index()
        {
            var posts = _repository.List();
            return View(posts);
        }


     
        [HttpGet]

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new Post());

            }
            else
            {
                var post = _repository.Get((int)id);
                return View(post);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            if (post.Id > 0)
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(post);

                }
                

            }
            else
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(post);
                }
                    
            }
            if (await _repository.Save())
            {
                return RedirectToAction("Index");
            }

            return View(post);
        }


        [HttpGet]

        public async Task<IActionResult> Remove(int id)
        {
            _repository.Delete(id);
            await _repository.Save();
            return RedirectToAction("Index");
        }
    }
}
