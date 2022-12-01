using BlogWithDb.Models;
using DataAccess.Entities;
using DataAccess.Repositorys;

namespace BlogWithDb.Services
{
    public class BlogCRUDService : IGenericCRUDService<BlogModel>
    {
        private readonly IGenericRepository<Blog> _addressRepository;
        public BlogCRUDService(IGenericRepository<Blog> addressRepositroy)
        {
            _addressRepository = addressRepositroy;
        }
        public async Task<BlogModel> Create(BlogModel model)
        {
            var blog = new Blog
            {
                Title = model.Title,
                Date = model.Date
            };
            var createBlog = await _addressRepository.Create(blog);
            var result = new BlogModel
            {
               Title=model.Title,
               Date=model.Date,
            };
            return result;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogModel>> Get()
        {
            var result = new List<BlogModel>();
            var blog = await _addressRepository.Get();
            foreach (var oneBlog in blog)
            {
                var model = new BlogModel
                {
                    Date = oneBlog.Date,
                    Title = oneBlog.Title
                };
                result.Add(model);
            }
            return result;
        }

        public Task<BlogModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogModel> Update(int id, BlogModel model)
        {
            throw new NotImplementedException();
        }
    }
}
