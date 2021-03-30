using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;
using MyBlog.Data.Repository;
using MyBlog.Models;
using MyBlog.ViewModels;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
            
        }
        public IActionResult Index()
        {
            var posts = _repository.List();
            return View(posts);
        }

        [HttpGet]

        public IActionResult Post(int id)
        {
            var post = _repository.Get(id);
            return View(post);
        }
        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                var post = _repository.Get(commentViewModel.PostID);

                if (commentViewModel.MainCommentId == 0)
                {
                    post.MainComments ??= new List<MainComment>();
                    post.MainComments.Add(new MainComment
                    {
                        Message = commentViewModel.Message,
                        Created = DateTime.Now
                    });
                    _repository.Update(post);
                }

                else
                {
                    var subComment = new SubComment
                    {
                        MainCommentId = commentViewModel.MainCommentId,
                        Message = commentViewModel.Message,
                        Created = DateTime.Now
                    };
                    _repository.AddSubComment(subComment);
                }
                await _repository.Save();
                return RedirectToAction("Post", new { id = commentViewModel.PostID });
            }
            return RedirectToAction("Post", new { id = commentViewModel.PostID });
        }
    }
}
