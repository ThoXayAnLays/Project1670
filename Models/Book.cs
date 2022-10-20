using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project1670.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Book Title length must be at least 3 characters")]
        [MaxLength(50, ErrorMessage = "Max Book Title length is 50 characters")]
        public string Title { get; set; }


        [Required]
        [Range(10, 100, ErrorMessage = "Price must be from 10 to 100")]
        public int Price { get; set; }


        [Required]
        [MinLength(5, ErrorMessage = "Book Description length must be at least 5 characters")]
        [MaxLength(300, ErrorMessage = "Max Book Description length is 300 characters")]
        [Display(Description = "Book Description")]
        public string Description { get; set; }


        [Required(ErrorMessage = "This field can not be blank!")]
        public string Image { get; set; }

        [Required]
        [Range(1,100)]
        public int Quantity { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
