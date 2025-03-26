using CQRS.Api.Domain.Entities;
using MediatR;

namespace CQRS.Api.Features.Users.CreateUser;

public record class CreateUserCommand(string FirstName, string LastName) : IRequest<User> { }
