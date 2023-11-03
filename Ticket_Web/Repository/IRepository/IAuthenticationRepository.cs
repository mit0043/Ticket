using Ticket_Web.Modal;

namespace Ticket_Web.Repository.IRepository
{
    public interface IAuthenticationRepository
    {
        bool IsUniqueUser(string userName);
        User Authenticate(string userName, string password);
    }
}
