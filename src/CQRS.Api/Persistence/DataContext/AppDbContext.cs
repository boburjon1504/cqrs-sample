using CQRS.Api.Domain.Entities;
using MongoDB.Driver;

namespace CQRS.Api.Persistence.DataContext;

public class AppDbContext(IMongoClient client)
{
    private readonly IMongoDatabase _dbContext = client.GetDatabase(nameof(AppDbContext));
    public IMongoCollection<User> Users => _dbContext.GetCollection<User>(nameof(User));
}
