namespace BlogWithDb.Models
{
    public class CommentResponseModel : CommentRegisterModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
    }
}
