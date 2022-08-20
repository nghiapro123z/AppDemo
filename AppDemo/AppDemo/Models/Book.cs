using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Book name must be at least 1 characters")]
        public string Name { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [Url]
        public string Image { get; set; }

        public Category Category { get; set; }

        public Author Author { get; set; }

        [Required]
        [Display(Name = "Author name:")]
        public int AuthorId { get; set; }


        [Required]
        [Display(Name = "Category name: ")]
        public int CategoryId { get; set; }

        //Book - Order: 1 to Many
        public ICollection<Order> Orders { get; set; }
    }
}
