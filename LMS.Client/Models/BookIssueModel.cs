using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Client.Models
{
    public class BookIssueModel
    {
        [Key]
        public string id { get; set; }
        public string member_email { get; set; }
        public string book_id { get; set; }
        [DisplayFormat(DataFormatString = Constants.DateOnlyFormat)]
        public DateTime issue_date { get; set; }
        [DisplayFormat(DataFormatString = Constants.DateOnlyFormat)]
        public DateTime due_date { get; set; }
        public string issue_status { get; set; }
    }
}
