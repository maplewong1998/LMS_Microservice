using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookIssues.API.Models
{
    public class BookIssue
    {
        [Column(TypeName = "nvarchar(50)")]
        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string member_email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string book_id { get; set; }
        [DisplayFormat(DataFormatString = Constants.DateOnlyFormat)]
        public DateTime issue_date { get; set; }
        [DisplayFormat(DataFormatString = Constants.DateOnlyFormat)]
        public DateTime due_date { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string issue_status { get; set; }
    }
}
