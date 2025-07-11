using System.ComponentModel.DataAnnotations;

namespace PersonalWebSite.Web.Models
{
    public class QuestionViewModel
    {
        [Required(ErrorMessage = "Başlık gereklidir")]
        [StringLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir")]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "İçerik gereklidir")]
        [Display(Name = "İçerik")]
        public string Content { get; set; } = string.Empty;
    }
} 