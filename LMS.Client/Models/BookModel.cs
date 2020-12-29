using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Client.Models
{
    public class BookModel
    {
        [Key]
        public string id { get; set; }
        public string book_name { get; set; }
        public string genre { get; set; }
        public string author_name { get; set; }
        public string publisher_name { get; set; }
        [DisplayFormat(DataFormatString = Constants.DateOnlyFormat)]
        public DateTime publish_date { get; set; }
        public string language { get; set; }
        public string edition { get; set; }
        public decimal book_cost { get; set; }
        public int no_of_pages { get; set; }
        public string book_description { get; set; }
        public int actual_stock { get; set; }
        public int issued_books { get; set; }
        public string book_img { get; set; }
    }
}
