using CQRS.Api.Domain.Entities;
using CQRS.Api.Persistence.Repositories;
using MediatR;

namespace CQRS.Api.Features.Users.GetAllUser;

public class GetAllUserCommandHandler(IUserRepository repository) : IRequestHandler<GetAllUserCommand, IList<User>>
{
    public Task<IList<User>> Handle(GetAllUserCommand request, CancellationToken cancellationToken)
    {
        return repository.GetAllAsync();
    }
}
