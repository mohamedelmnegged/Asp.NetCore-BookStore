using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; } 

        [Required(AllowEmptyStrings =false, ErrorMessage ="please enter valid Name")]
        [StringLength(100, MinimumLength =3)]
        public string Name { get; set; }

        [Required]
        public DateTime PublishDay { get; set; }  

        public string ImageUrl { get; set; }
        [Required]
        public Author Author { get; set; }
    }
}
