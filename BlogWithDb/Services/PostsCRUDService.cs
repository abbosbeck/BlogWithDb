using BlogWithDb.Models;
using DataAccess.Entities;
using DataAccess.Repositorys;

namespace BlogWithDb.Services
{
    public class PostsCRUDService : IGenericCRUDService<PostsModel>
    {
        private readonly IGenericRepository<Posts> _addressRepository;
        public PostsCRUDService(IGenericRepository<Posts> addressRepositroy)
        {
            _addressRepository = addressRepositroy;
        }

        public async Task<PostsModel> Create(PostsModel model)
        {
            var Post = new Posts
            {
                Title = model.Title,
                BlogId = model.BlogId,
                Text = model.Text
            };
            var createPost = await _addressRepository.Create(Post);
            var result = new PostsModel
            {
                Title = createPost.Title,
                BlogId = createPost.BlogId,
                Text = createPost.Text
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _addressRepository.Delete(id);
        }

        public async Task<IEnumerable<PostsModel>> Get()
        {
            var result = new List<PostsModel>();
            var posts = await _addressRepository.Get();
            foreach (var post in posts)
            {
                var model = new PostsModel
                {
                   Title = post.Title,
                   Text = post.Text,
                   BlogId = post.BlogId
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<PostsModel> Get(int id)
        {
            var model = await _addressRepository.Get(id);
            var result = new PostsModel
            {
                Title=model.Title,
                Text = model.Text,
                BlogId = model.BlogId
            };
            return result;
        }

        public async Task<PostsModel> Update(int id, PostsModel model)
        {
            var post = new Posts
            {
                Title = model.Title,
                Text=model.Text,
                BlogId=model.BlogId
            };
            var updatePost = await _addressRepository.Update(id, post);
            var result = new PostsModel
            {
                Text = updatePost.Text,
                Title = updatePost.Title,
                BlogId = updatePost.BlogId
            };
            return result;
        }
    }
}
