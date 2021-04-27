using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;

namespace SocialMedia.Infraestructure.Repositories
{
  public class BaseRepository<T> : IRepository<T> where T : BaseEntity
  {

    private readonly SocialMediaContext _context;
    private readonly DbSet<T> _entity;
    public BaseRepository(SocialMediaContext context)
    {
      _context = context;
      _entity = context.Set<T>();

    }

    public async Task<IEnumerable<T>> GetAll()
    {
      return await _entity.ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
      return await _entity.FindAsync(id);
    }
    public async Task Add(T entity)
    {
      _entity.Add(entity);
      await _context.SaveChangesAsync();
    }
    public async Task Update(T entity)
    {
      _entity.Update(entity);
      await _context.SaveChangesAsync();
    }
    public async Task Delete(int id)
    {
      var entity = await GetById(id);
      _entity.Remove(entity);
      await _context.SaveChangesAsync();
    }
  }
}
