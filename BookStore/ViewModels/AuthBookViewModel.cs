using BookStore.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class AuthBookViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength =3)]
        public string Name { get; set; }

        [Required]
        public DateTime PublishDay { get; set; }
        public IList<Author> Authors { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Display(Name="Image")]
        public IFormFile File { get; set; }

        [Display(Name="Image")]
        public string ImageUrl { get; set;  }
    }
}
