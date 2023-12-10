using lms.Models;

namespace lms.DataAccess.Abstract
{
    public interface IOrder
    {
        bool bookBorrow(int userid, int bookid);

        IEnumerable<object> MyOrder(int userid);

        order returnBook(int orderid, int bookid);
    }
}
