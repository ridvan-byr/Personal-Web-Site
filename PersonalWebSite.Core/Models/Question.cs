using System.ComponentModel.DataAnnotations;

namespace PersonalWebSite.Core.Models
{
    public class Question : BaseEntity
    {
        [Required(ErrorMessage = "Başlık gereklidir")]
        [StringLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir")]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "İçerik gereklidir")]
        [Display(Name = "İçerik")]
        public string Content { get; set; } = string.Empty;

        [Display(Name = "Kullanıcı")]
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!;

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
} 