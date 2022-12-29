using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositorys
{
    public class PostRepository : IGenericRepository<Posts>
    {
        private readonly AppDbContext _dbContext;

        public PostRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Posts> Create(Posts elemnt)
        {
            await _dbContext.Posts.AddAsync(elemnt);
            await _dbContext.SaveChangesAsync();
            return elemnt;
        }

        public async Task<bool> Delete(int id)
        {
            var country = await _dbContext.Posts.FindAsync(id);
            if (country != null)
            {
                _dbContext.Posts.Remove(country);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Posts>> Get()
        {
            return await _dbContext.Posts.OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<Posts> Get(int id)
        {
            return await _dbContext.Posts.FindAsync(id);
        }

        public async Task<Posts> Update(int id, Posts country)
        {
            var updatedCountry = _dbContext.Posts.Attach(country);
            updatedCountry.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return country;
        }
    }
}
