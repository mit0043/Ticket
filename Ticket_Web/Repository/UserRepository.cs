using Microsoft.EntityFrameworkCore;
using Ticket_Web.Data;
using Ticket_Web.Migrations;
using Ticket_Web.Modal;
using Ticket_Web.Repository.IRepository;

namespace Ticket_Web.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _Context;
        public UserRepository(ApplicationDbContext context)
        {
            _Context = context;     
        }
        public bool CreateUser(User user)
        {
            _Context.Users.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _Context.Users.Remove(user);
            return Save();
        }

        public ICollection<User> GetAllUser()
        {
            return _Context.Users.Include(u => u.Department).Include(u => u.Role).ToList();
        }

        public User GetUser(int userId)
        {
            return _Context.Users.Find(userId);
        }

        public bool Save()
        {
            return _Context.SaveChanges() == 1 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _Context.Users.Update(user);
            return Save();
        }
        public bool UserExistId(int userId)
        {
            return _Context.Users.Any(u => u.iUserId == userId);
        }

        public bool UserExistName(string userName)
        {
            return _Context.Users.Any(u => u.vUserName == userName);
        }
    }
}
