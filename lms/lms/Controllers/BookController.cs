using lms.DataAccess.Abstract;
using lms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace lms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _book;
        public BookController(IBook book)
        {
            _book = book;
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook(book book)
        {
            var addbook = _book.addbook(book);

            if (addbook == true)
            {
                return Ok("Book Added");
            }
            return Ok("Error while adding");
        }

        [HttpGet("GetAllAvailableBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _book.getavailablebooks();

            if (!books.IsNullOrEmpty())
            {
                var booksdata = books.Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.Author,
                    b.Genre,
                    b.Rating,
                });

                return Ok(booksdata);
            }

            return Ok("No Book Data Found");
        }

        [HttpGet("GetAllAvailableBooksById/{userid}")]
        public IActionResult GetAllBooksById(int userid)
        {
            var books = _book.getavailablebooksbyid(userid);

            if (!books.IsNullOrEmpty())
            {
                var booksdata = books.Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.Author,
                    b.Genre,
                    b.Rating,
                });

                return Ok(booksdata);
            }

            return Ok(books);
        }

        [HttpGet("GetBookById/{bookId}")]
        public IActionResult GetBook(int bookId)
        {
            var book = _book.GetBook(bookId);

            if (!book.IsNullOrEmpty())
            {
                return Ok(book);
            }
            return Ok("Book not found");
        }

        [HttpGet("BookRating/{bookId}/{rating}")]
        public IActionResult BookRating(int bookId, int rating)
        {
            var book = _book.bookRating(bookId, rating);

            if (book != 0)
            {
                return Ok(new { bookrating = book, message = "Rating Successful"});
            }
            return Ok("Error while rating");
        }

        [HttpGet("MyBooks/{userId}")]
        public IActionResult MyBooks(int userId)
        {
            var books = _book.MyBooks(userId);

            if (!books.IsNullOrEmpty())
            {
                var bookdata = books.Select(b => new {
                    b.Title,
                    b.Author,
                    b.Genre,
                    b.Description,
                    b.Rating
                });
                return Ok(bookdata);
            }

            return Ok(books);
        }
    }
}
