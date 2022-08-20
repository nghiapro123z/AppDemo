﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}
