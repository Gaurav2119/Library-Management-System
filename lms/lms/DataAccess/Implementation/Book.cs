using lms.context;
using lms.DataAccess.Abstract;
using lms.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace lms.DataAccess.Implementation
{
    public class Book : IBook
    {
        private readonly AppDBContext _dbContext;
        public Book(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public bool addbook(book book)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.id == book.lentByUser);

            if (user != null)
            {
                user.token += 1;

                book bookadd = new book
                {
                    Title = book.Title,
                    Author = book.Author,
                    Genre = book.Genre,
                    Description = book.Description,
                    lentByUser = user.id,
                };

                _dbContext.Books.Add(bookadd);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public IEnumerable<book> getavailablebooks()
        {
            var books = _dbContext.Books.Where(b => b.IsAvailable == true).ToList();

            return books;
        }

        public IEnumerable<book> getavailablebooksbyid(int userid)
        {
            var books = _dbContext.Books.Where(b => b.IsAvailable == true && b.lentByUser != userid).ToList();

            return books;
        }

        public IEnumerable<object> GetBook(int bookId)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.id == book.lentByUser);

                if (user != null)
                {
                    var bookToSend = new
                    {
                        book.Id,
                        book.Title,
                        book.Author,
                        book.Genre,
                        book.Description,
                        book.Rating,
                        lentbyusername = user.name
                    };
                    yield return bookToSend;
                }
            }
            yield break;
        }

        public double bookRating(int bookId, int rating)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == bookId);

            if (book != null && rating > 0)
            {
                if (book.Rating == 0)
                {
                    book.Rating = rating;
                }
                book.Rating = Math.Round((book.Rating + rating) / 2, 2);

                _dbContext.SaveChanges();

                return book.Rating;
            }
            return 0;
        }

        public IEnumerable<book> MyBooks(int userId)
        {
            var book = _dbContext.Books.Where(b => b.lentByUser == userId);

            return book.ToList();
        }
    }
}
