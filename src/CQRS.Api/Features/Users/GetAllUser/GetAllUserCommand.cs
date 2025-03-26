using CQRS.Api.Domain.Entities;
using MediatR;

namespace CQRS.Api.Features.Users.GetAllUser;

public record class GetAllUserCommand : IRequest<IList<User>> { }
