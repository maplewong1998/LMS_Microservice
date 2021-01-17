using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookIssues.API.Models
{
    public class BookIssuesAPIContext : DbContext
    {
        public BookIssuesAPIContext (DbContextOptions<BookIssuesAPIContext> options)
            : base(options)
        {
        }

        public DbSet<BookIssue> BookIssues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookIssue>().HasData(
                    new BookIssue
                    {
                        id = 1,
                        member_email = "admin@email.com",
                        book_id = "978-0062316097",
                        issue_date = new DateTime(2021, 01, 01),
                        due_date = new DateTime(2016, 01, 07),
                        issue_status = "Returned"
                    }
                );
        }
    }
}
