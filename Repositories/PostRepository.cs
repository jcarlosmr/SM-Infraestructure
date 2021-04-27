using System.Collections.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;
using SocialMedia.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Infraestructure.Repositories
{
  public class PostRepository : IPostRepository
  {

    public readonly SocialMediaContext _context;
    public PostRepository(SocialMediaContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Post>> GetPosts()
    {
      var posts = await _context.Posts.ToListAsync();
      return posts;
    }
    public async Task<Post> GetPostById(int Id)
    {
      var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == Id);
      return post;
    }

    public async Task InserPost(Post post)
    {
      _context.Posts.Add(post);
      await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdatePost(Post post)
    {
      var currentPost = await GetPostById(post.Id);
      currentPost.Date = post.Date;
      currentPost.Description = post.Description;
      currentPost.Image = post.Image;
      int rows = await _context.SaveChangesAsync();
      return rows > 0;
    }

    public async Task<bool> DeletePost(int Id)
    {
      var postToDelete = await GetPostById(Id);
      _context.Posts.Remove(postToDelete);
      int rows = await _context.SaveChangesAsync();
      return rows > 0;
    }
  }
}
