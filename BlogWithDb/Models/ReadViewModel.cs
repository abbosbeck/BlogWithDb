namespace BlogWithDb.Models
{
    public class ReadViewModel
    {
        public List<CommentResponseModel> Comments { get; set; }
        public PostResponseModel Posts { get; set; }
        public CommentRegisterModel CommentRegister { get; set; }
    }
}
