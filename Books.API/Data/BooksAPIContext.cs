using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Books.API.Models;

namespace Books.API.Data
{
    public class BooksAPIContext : DbContext
    {
        public BooksAPIContext (DbContextOptions<BooksAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                    new Book
                    {
                        id = "978-0062316097",
                        book_name = "Sapiens: A Brief History of Mankind",
                        genre = "History, Science, Philosophy",
                        author_name = "Yuval Noah Harari",
                        publisher_name = "Vintage Publishing",
                        publish_date = new DateTime(2016, 09, 15),
                        language = "English",
                        edition = "1st Edition",
                        book_cost = 66.00M,
                        no_of_pages = 464,
                        book_description = "Yuval Noah Harari has some questions. Among the biggest: How did Homo sapiens (or Homo sapiens sapiens , if you’re feeling especially wise today) evolve from an unexceptional savannah-dwelling primate to become the dominant force on the planet, emerging as the lone survivor out of six distinct, competing hominid species? He also has some answers, and they’re not what you’d expect. Tackling evolutionary concepts from a historian’s perspective, Sapiens: A Brief History of Humankind, describes human development through a framework of three not-necessarily-orthodox “Revolutions”: the Cognitive, the Agricultural, and the Scientific.",
                        actual_stock = 5,
                        issued_books = 0,
                        book_img = "b6.jpg"
                    }
                );
        }
    }
}
