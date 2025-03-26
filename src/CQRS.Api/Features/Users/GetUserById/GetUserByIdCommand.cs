using CQRS.Api.Domain.Entities;
using MediatR;

namespace CQRS.Api.Features.Users.GetUserById;

public record class GetUserByIdCommand(Guid Id) : IRequest<User>
{
}
