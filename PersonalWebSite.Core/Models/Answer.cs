using System.ComponentModel.DataAnnotations;

namespace PersonalWebSite.Core.Models
{
    public class Answer : BaseEntity
    {
        [Required(ErrorMessage = "İçerik gereklidir")]
        [Display(Name = "İçerik")]
        public string Content { get; set; } = string.Empty;

        [Display(Name = "Soru")]
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;

        [Display(Name = "Kullanıcı")]
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!;
    }
} 