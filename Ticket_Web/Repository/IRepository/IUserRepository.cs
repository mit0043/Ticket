using Ticket_Web.Modal;

namespace Ticket_Web.Repository.IRepository
{
    public interface IUserRepository
    {
        ICollection<User> GetAllUser();

        User GetUser(int userId);

        bool UserExistId(int userId);

        bool UserExistName(string userName);

        bool CreateUser(User user);

        bool UpdateUser(User user);

        bool DeleteUser(User user);

        bool Save();
    }
}
