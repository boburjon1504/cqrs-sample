using CQRS.Api.Domain.Entities;
using CQRS.Api.Persistence.Repositories;
using MediatR;

namespace CQRS.Api.Features.Users.CreateUser;

public class CreateUserCommandHandler(IUserRepository repository) : IRequestHandler<CreateUserCommand, User>
{
    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.CreateAsync(new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName
        });

        return user;
    }
}
