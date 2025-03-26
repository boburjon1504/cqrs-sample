using CQRS.Api.Domain.Entities;
using CQRS.Api.Persistence.Repositories;
using MediatR;

namespace CQRS.Api.Features.Users.GetUserById;

public class GetUserByIdCommandHandler(IUserRepository repository) : IRequestHandler<GetUserByIdCommand, User>
{
    public Task<User> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
    {
        return repository.GetByIdAsync(request.Id);
    }
}
