using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Models
{
    public class Book
    {
        [Column(TypeName = "nvarchar(50)")]
        [Key]
        public string id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string book_name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string genre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string author_name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string publisher_name { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = Constants.DateOnlyFormat)]
        public DateTime publish_date { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string language { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string edition { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal book_cost { get; set; }
        [Column(TypeName = "int")]
        public int no_of_pages { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string book_description { get; set; }
        [Column(TypeName = "int")]
        public int actual_stock { get; set; }
        [Column(TypeName = "int")]
        public int issued_books { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string book_img { get; set; }
    }
}
