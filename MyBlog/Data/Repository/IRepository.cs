using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.Models;

namespace MyBlog.Data.Repository
{
    public interface IRepository
    {
        Post Get(int id);
        List<Post> List();
        void Delete(int id);
        void Update(Post post);
        void Add(Post post);
        Task<bool> Save();
        void AddSubComment(SubComment subComment);
    }
}
