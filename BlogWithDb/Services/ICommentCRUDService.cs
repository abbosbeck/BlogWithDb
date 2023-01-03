namespace BlogWithDb.Services
{
    public interface ICommentCRUDService<CommentResponseModel, CommentRegisterModel>
    {
        Task<IEnumerable<CommentResponseModel>> Get();
        Task<CommentResponseModel> Create(CommentRegisterModel model);
        Task<IEnumerable<CommentResponseModel>> Get(int id);
        Task<CommentResponseModel> Update(int id, CommentResponseModel model);
        Task<bool> Delete(int id);
    }
}
