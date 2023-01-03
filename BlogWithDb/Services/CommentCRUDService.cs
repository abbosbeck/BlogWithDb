using BlogWithDb.Models;
using DataAccess.Entities;
using DataAccess.Repositorys;

namespace BlogWithDb.Services
{
    public class CommentCRUDService : ICommentCRUDService<CommentResponseModel, CommentRegisterModel>
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        public CommentCRUDService(IGenericRepository<Comment> addressRepositroy)
        {
            _commentRepository = addressRepositroy;
        }

        public async Task<CommentResponseModel> Create(CommentRegisterModel model)
        {
            var comment = new Comment()
            {
                Name = model.Name,
                Text = model.Text,
                PostId = model.PostId,
            };
            var createComment = await _commentRepository.Create(comment);
            var result = new CommentResponseModel()
            {
                Id = createComment.Id,
                Name = createComment.Name,
                Text = createComment.Text,
                PostId = createComment.PostId
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _commentRepository.Delete(id);
        }

        public async Task<IEnumerable<CommentResponseModel>> Get()
        {
            var result = new List<CommentResponseModel>();
            var comments = await _commentRepository.Get();
            foreach (var comment in comments)
            {
                var model = new CommentResponseModel
                {
                       Id = comment.Id,
                       Name = comment.Name,
                       Text = comment.Text,
                       PostId = comment.PostId
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<IEnumerable<CommentResponseModel>> Get(int id)
        {
            var result = new List<CommentResponseModel>();
            var comments = await _commentRepository.Get();
            foreach (var comment in comments)
            {
                if(comment.PostId == id)
                {
                    var model = new CommentResponseModel
                    {
                        Id = comment.Id,
                        Name = comment.Name,
                        Text = comment.Text,
                        PostId = comment.PostId
                    };
                    result.Add(model);
                }
            }
            return result;
        }

        public async Task<CommentResponseModel> Update(int id, CommentResponseModel model)
        {
            var comment = new Comment
            {
                Id = id,
                PostId = model.PostId,
                Name = model.Name,
                Text = model.Text
            };
            var updateComment = await _commentRepository.Update(id, comment);
            var result = new CommentResponseModel
            {
                Id = updateComment.Id,
                Text = updateComment.Text,
                Name = updateComment.Name,
                PostId = updateComment.PostId
            };
            return result;
        }
    }
}
