using BookStoreDAL.Data;
using BookStoreDAL.Models;
using BookStoreDAL.Contracts;
namespace BookStoreDAL.Repository
{
    public class UserRepository :IUserRepository
    {
        public User? GetUser(string userName)
        {
            using (var context = new BookStoreDBContext())
            {
                return context.Users.FirstOrDefault(u => u.UserName == userName);
            }
        }

        public void AddUser(User user)
        {
            using (var context = new BookStoreDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool IsExist(User user)
        {
            using (var context = new BookStoreDBContext())
            {
                int count = context.Users
                                   .Where(u => (u.UserName == user.UserName) && (u.Password == user.Password))
                                   .Count();
                if (count > 0)
                    return true;

                return false;

            }
        }
    }
}
