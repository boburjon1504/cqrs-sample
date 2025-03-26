using CQRS.Api.Domain.Entities;
using CQRS.Api.Persistence.DataContext;
using MongoDB.Driver;

namespace CQRS.Api.Persistence.Repositories;

public class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public async Task<IList<User>> GetAllAsync()
    {
        return await dbContext.Users.Find(_=>true).ToListAsync();
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await dbContext.Users.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<User> CreateAsync(User user)
    {
        await dbContext.Users.InsertOneAsync(user);

        return user;
    }
}
