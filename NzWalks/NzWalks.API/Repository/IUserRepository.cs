using NzWalks.API.Model.Domain;

namespace NzWalks.API.Repository
{
    public interface IUserRepository
    {

        Task<User> AuthenticateUser(string username, string password);
    }
}
