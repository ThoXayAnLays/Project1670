using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System;

namespace Project1670.Models
{
    public class Order
    {
        public int Id { get; set; }     
        public string UserEmail { get; set; }
        [Required]
        public int OrderQuantity { get; set; }
        [Required]
        public double OrderPrice { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
