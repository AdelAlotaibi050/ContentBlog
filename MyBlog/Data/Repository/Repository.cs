using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlog.Models;

namespace MyBlog.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async void Add(Post post)
        {
            await _dataContext.Posts.AddAsync(post);
        }

        public void AddSubComment(SubComment subComment)
        {

            _dataContext.SubComments.Add(subComment);
        }

        public void Delete(int id)
        {
            _dataContext.Posts.Remove(Get(id));
        }

        public Post Get(int id)
        {
            return _dataContext.Posts.
                Include(p=>p.MainComments).
                ThenInclude(mc => mc.SubComments).
                FirstOrDefault(x => x.Id == id);
        }

        public List<Post> List()
        {
            return _dataContext.Posts.ToList();
        }

        public async Task<bool> Save()
        {
            if(await _dataContext.SaveChangesAsync() > 0)
            {
                return true;
            }
           return false ;
        }

        public void Update(Post post)
        {
            _dataContext.Posts.Update(post);
        }
    }
}
