﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture URL")]
        public IFormFile ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName { get; set; }

        [Display(Name = "Biography")]
        public string? Bio { get; set; }
        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
