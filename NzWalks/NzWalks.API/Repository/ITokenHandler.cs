using NzWalks.API.Model.Domain;

namespace NzWalks.API.Repository
{
    public interface ITokenHandler
    {
        Task<string> CreateJwtToke(User user);
    }
}
