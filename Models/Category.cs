using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Project1670.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        [MinLength(3, ErrorMessage = "Category Name length must be at least 3 characters")]
        [MaxLength(30, ErrorMessage = "Max Category Name Length is 30 characters")]
        public string Name { get; set; }


        [Required]
        [Display(Description = "Category Description")]
        [MinLength(5, ErrorMessage = "Category Description length must be at least 5 characters")]
        [MaxLength(500, ErrorMessage = "Max Category Description Length is 500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field can not be blank!")]
        public string Image { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
