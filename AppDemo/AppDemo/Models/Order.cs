using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int BookId { get; set; }  //FK : liên kết sang PK của bảng Book

        //Order - Book: Many To One
        public Book Book { get; set; }  //dùng để truy xuất các thông tin của bảng Book

        public string UserEmail { get; set; }

        [Required]
        public int OrderQuantity { get; set; }

        [Required]
        public double OrderPrice { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
    }
}
