using System.ComponentModel.DataAnnotations;

namespace BlogWithDb.Models
{
    public class TelegramMessageModel
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Telegram { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}
