using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public class BlogRepositroy : IGenericRepository<Blog>
    {
        private readonly AppDbContext _dbContext;

        public BlogRepositroy(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Blog> Create(Blog elemnt)
        {
            await _dbContext.Blog.AddAsync(elemnt);
            await _dbContext.SaveChangesAsync();
            return elemnt;
        }

        public async Task<bool> Delete(int id)
        {
            var country = await _dbContext.Blog.FindAsync(id);
            if (country != null)
            {
                _dbContext.Blog.Remove(country);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Blog>> Get()
        {
            return await _dbContext.Blog.ToListAsync();
        }

        public async Task<Blog> Get(int id)
        {
            return await _dbContext.Blog.FindAsync(id);
        }

        public async Task<Blog> Update(int id, Blog country)
        {
            var updatedCountry = _dbContext.Blog.Attach(country);
            updatedCountry.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return country;
        }
    }
}
