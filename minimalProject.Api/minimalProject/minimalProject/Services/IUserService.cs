using minimalProject.Core;
using minimalProject.Core.Domains.User;
using minimalProject.Frameworks.Autofac;
using minimalProject.Models.User;

namespace minimalProject.Services
{
    public interface IUserService : IScopedDependency
    {
        Task<User> AddUser(AddUserInput addUserInput, CancellationToken cancellationToken);
        Task<User> GetUserById(int id, CancellationToken cancellationToken);
        IQueryable<User> GetUsers(IInclude<User> include = null);
    }
}
