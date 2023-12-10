using lms.context;
using lms.DataAccess.Abstract;
using lms.Models;

namespace lms.DataAccess.Implementation
{
    public class User : IUser
    {
        private readonly AppDBContext _dbContext;

        public User(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public user authenticate(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.username == username && u.password == password);

            if (user != null)
            {
                return user;
            }

            return null;
        }

        public user GetUser(int userid)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.id == userid);
            
            if(user != null)
            {
                return user;
            }

            return null;
        }
    }
}
