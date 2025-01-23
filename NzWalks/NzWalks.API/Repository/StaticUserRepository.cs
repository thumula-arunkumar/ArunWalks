
using NzWalks.API.Model.Domain;

namespace NzWalks.API.Repository
{
    public class StaticUserRepository : IUserRepository
    {

        private List<User> users = new List<User>()
        {
            new User
            {
                Id = Guid.NewGuid(),
                Name = "Arunkumar", 
                Password = "Arun123",
                Email = "Arun@gmail.com", 
                Roles = new List<string> {"reader"}, 
                Firstname = "Arunkumar",
                Lastname = "Thumula"
            },

            new User
            {
                Id = Guid.NewGuid(),
                Name = "Ajay",
                Password = "Ajay123",
                Email = "Ajay@gmail.com",
                Roles = new List<string> {"reader", "writer"},
                Firstname = "Ajay",
                Lastname = "Thumula"
            },

        };

        public async Task<User> AuthenticateUser(string username, string password)
        {
            var user = users.Find(x => x.Name.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);
            if(user != null)
            {
                return user;
            }
            return null;
        }
    }
}
