using BlogWithDb.Models;
using DataAccess.Entities;
using DataAccess.Repositorys;

namespace BlogWithDb.Services
{
    public class PostsCRUDService : IGenericCRUDService<PostResponseModel, PostRegisterModel>
    {
        private readonly IGenericRepository<Posts> _addressRepository;
        public PostsCRUDService(IGenericRepository<Posts> addressRepositroy)
        {
            _addressRepository = addressRepositroy;
        }

        public async Task<PostResponseModel> Create(PostRegisterModel model)
        {
            var Post = new Posts
            {
                Title = model.Title,
                Text = model.Text,
                Date = DateTime.Now.ToString("dd MMMM, yyyy")

        };
            var createPost = await _addressRepository.Create(Post);
            var result = new PostResponseModel
            {
                Id = createPost.Id,
                Title = createPost.Title,
                Text = createPost.Text,
                Date= createPost.Date
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _addressRepository.Delete(id);
        }

        public async Task<IEnumerable<PostResponseModel>> Get()
        {
            var result = new List<PostResponseModel>();
            var posts = await _addressRepository.Get();
            foreach (var post in posts)
            {
                var model = new PostResponseModel
                {
                   Id=post.Id,
                   Title = post.Title,
                   Text = post.Text,
                   Date = post.Date
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<PostResponseModel> Get(int id)
        {
            var model = await _addressRepository.Get(id);
            var result = new PostResponseModel
            {
                Id = model.Id,
                Title=model.Title,
                Text = model.Text,
                Date = model.Date
            };
            return result;
        }

        public async Task<PostResponseModel> Update(int id, PostResponseModel model)
        {
            var post = new Posts
            {
                Id = id,
                Title = model.Title,
                Text=model.Text,
                Date = model.Date
            };
            var updatePost = await _addressRepository.Update(id, post);
            var result = new PostResponseModel
            {
                Id= updatePost.Id,
                Text = updatePost.Text,
                Title = updatePost.Title,
                Date = updatePost.Date
            };
            return result;
        }
    }
}
