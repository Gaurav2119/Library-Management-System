using lms.DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _order;
        public OrderController(IOrder order)
        {
            _order = order;
        }

        [HttpGet("BorrowBook/{userid}/{bookid}")]
        public IActionResult BorrowBook(int userid, int bookid)
        {
            var placed = _order.bookBorrow(userid, bookid);

            if (placed == true)
                return Ok("Order placed");

            return Ok("Enough Token Not Available!");
        }

        [HttpGet("MyOrder/{userid}")]
        public IActionResult MyOrder(int userid)
        {
            return Ok(_order.MyOrder(userid));
        }

        [HttpGet("ReturnBook/{orderid}/{bookid}")]
        public IActionResult ReturnBook(int orderid,  int bookid)
        {
            var is_returned = _order.returnBook(orderid, bookid);

            if (is_returned != null)
            {
                return Ok(new
                {
                    returnedOn = is_returned.borrowedUntil,
                    message = "Return Successfull"
                });
            }

            return Ok("Error while returning");
        }
    }
}
