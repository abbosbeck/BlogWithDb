using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public class CommentRepository : IGenericRepository<Comment>
    {
        private readonly AppDbContext _dbContext;

        public CommentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Comment> Create(Comment element)
        {
            await _dbContext.Comments.AddAsync(element);
            await _dbContext.SaveChangesAsync();
            return element;
        }

        public async Task<bool> Delete(int id)
        {
            var comment = await _dbContext.Comments.FindAsync(id);
            if (comment != null)
            {
                _dbContext.Comments.Remove(comment);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Comment>> Get()
        {
            return await _dbContext.Comments.ToListAsync();

        }

        public async Task<Comment> Get(int id)
        {
            return await _dbContext.Comments.FindAsync(id);
        }

        public async Task<Comment> Update(int id, Comment element)
        {
            var updatedComment = _dbContext.Comments.Attach(element);
            updatedComment.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return element;
        }
    }
}
