using BookApp.Controllers;
using BookApp.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System.Diagnostics;

namespace TestBooksController
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IndexTest([Values(1, 2, 3)] int x)
        {
            var options = new DbContextOptionsBuilder<BookDataDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            var context = new BookDataDbContext(options);
            var logger = new NullLogger<BooksController>();

            BooksController booksController = new BooksController(context, logger);

            var bookA = new Book()
            {
                Title = $"Title Number {x}",
                Author = "Author Number 1",
                NumberOfPages = 117,
                Publisher = "Publisher Number 1",
                Price = 25.95,
                ISBN = "1234567890123",
                Category = "Category Number 1",
                Created = new DateTime(year:2022, month: 6, day: 15, hour: 17, minute: 43, second: 34),
            };

            var result = booksController.Create(bookA);

            Debug.WriteLine(bookA.Id);

            result.Should().BeOfType<Task<IActionResult>>();

            var bookB = context.Books.Where(i => i.Id == bookA.Id).FirstOrDefault();

            bookB.Should().BeOfType<Book>();

            Assert.That(bookB.Id, Is.EqualTo(bookA.Id));
            Assert.That(bookB.Title, Is.EqualTo($"Title Number {x}"));
            Assert.That(bookB.Author, Is.EqualTo("Author Number 1"));
            Assert.That(bookB.NumberOfPages, Is.EqualTo(117));
            Assert.That(bookB.Publisher, Is.EqualTo("Publisher Number 1"));
            Assert.That(bookB.Price, Is.EqualTo(25.95));
            Assert.That(bookB.ISBN, Is.EqualTo("1234567890123"));
            Assert.That(bookB.Category, Is.EqualTo("Category Number 1"));
            Assert.That(bookB.Created, Is.EqualTo(new DateTime(year: 2022, month: 6, day: 15, hour: 17, minute: 43, second: 34)));
        }
    }
}