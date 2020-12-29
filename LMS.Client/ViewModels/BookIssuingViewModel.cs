using LMS.Client.Models;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Client.ViewModels
{
    public class BookIssuingViewModel
    {
        public IEnumerable<BookIssueModel> issue_list { get; set; }
        public BookIssueModel issue { get; set; }
    }
}
