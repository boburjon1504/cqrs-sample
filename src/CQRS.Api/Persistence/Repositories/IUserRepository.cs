using CQRS.Api.Domain.Entities;

namespace CQRS.Api.Persistence.Repositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);

    Task<IList<User>> GetAllAsync();

    Task<User> GetByIdAsync(Guid id);
}
