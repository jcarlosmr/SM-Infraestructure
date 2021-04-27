using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;

namespace SocialMedia.Infraestructure.Repositories
{
  public class UserRepository : IUserRepository
  {
    public readonly SocialMediaContext _context;
    public UserRepository(SocialMediaContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
      var Users = await _context.Users.ToListAsync();
      return Users;
    }
    public async Task<User> GetUserById(int Id)
    {
      var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);
      return user;
    }
  }
}
