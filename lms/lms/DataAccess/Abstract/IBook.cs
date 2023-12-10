using lms.Models;

namespace lms.DataAccess.Abstract
{
    public interface IBook
    {
        bool addbook(book book);

        IEnumerable<book> getavailablebooks();
        IEnumerable<book> getavailablebooksbyid(int userid);

        IEnumerable<object> GetBook(int bookId);

        double bookRating(int bookId, int rating);

        IEnumerable<book> MyBooks(int userId);
    }
}
