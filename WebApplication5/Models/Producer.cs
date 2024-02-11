using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }
        [Display(Name = "Profile Picture")]
        public IFormFile ProfilePictureURL { get; set; }
        [Display(Name = "FullName")]
        public string? FullName { get; set; }

        [Display(Name = "Biography")]
        public string? Bio { get; set; }
        public List<Movie> Movies { get; set; }
    }

}