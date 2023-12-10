using lms.context;
using lms.DataAccess.Abstract;
using lms.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace lms.DataAccess.Implementation
{
    public class Order : IOrder
    {
        private readonly AppDBContext _dbContext;
        public Order(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public bool bookBorrow(int userid, int bookid)
        {
            order placeOrder = new order
            {
                bookid = bookid,
                borrowedByUser = userid,
                borrowedOn = DateTime.Now,
            };

            var placed = _dbContext.Orders.Add(placeOrder);

            if(placed.Entity != null )
            {
                var existingBook = _dbContext.Books.FirstOrDefault(b => b.Id == bookid);

                var existingUser = _dbContext.Users.FirstOrDefault(u => u.id == userid);

                if (existingBook != null && existingUser != null && existingBook.IsAvailable == true && existingUser.token > 0 && existingBook.lentByUser != userid)
                {
                    existingBook.IsAvailable = false;
                    existingBook.currentlyBorrowedByUser = userid;
                    existingUser.token -= 1;

                    var lentUser = _dbContext.Users.FirstOrDefault(lu => lu.id == existingBook.lentByUser);

                    if (lentUser != null)
                    {
                        lentUser.token += 1;

                        _dbContext.SaveChanges();

                        return true;
                    }
                }
            }

            return false;
        }

        public IEnumerable<object> MyOrder(int userid)
        {
            var orders = _dbContext.Orders
                .Where(o => o.borrowedByUser == userid)
                .Join(_dbContext.Books,
                ot => ot.bookid,
                bt => bt.Id,
                (ot, bt) => new
                {
                    OrderId = ot.Id,
                    UserId = ot.borrowedByUser,
                    BookId = ot.bookid,
                    BorrowedOn = ot.borrowedOn,
                    ReturnedOn = ot.borrowedUntil,
                    Is_Returned = ot.is_returned,
                    BookName = bt.Title,
                    BookAuthor = bt.Author,
                });

            return orders;
        }

        public order returnBook(int orderid, int bookid)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == bookid);
            var bookreturn = _dbContext.Orders.FirstOrDefault(o => o.Id == orderid);

            if (book != null && bookreturn != null)
            {
                book.IsAvailable = true;
                book.currentlyBorrowedByUser = 0;
                bookreturn.borrowedUntil = DateTime.Now;
                bookreturn.is_returned = true;

                _dbContext.SaveChanges();
                return (bookreturn);
            }
            return null;
        }
    }
}
