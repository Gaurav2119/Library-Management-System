using lms.Models;

namespace lms.DataAccess.Abstract
{
    public interface IUser
    {
        user authenticate(string username, string password);
        user GetUser(int userid);
    }
}
