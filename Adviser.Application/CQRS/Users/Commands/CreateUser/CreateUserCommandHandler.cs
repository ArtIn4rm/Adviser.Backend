using MediatR;
using Adviser.Domain;
using Adviser.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Adviser.Application.Common.Exceptions;

namespace Adviser.Application.CQRS.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IDbContext _dbContext;

        public CreateUserCommandHandler(IDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                RegistrationDate = DateTime.Now,
                NumberOfLikes = 0,
                IsAdmin = false,
            };
            await CheckIfTaken(request, cancellationToken);
            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return user.Id;
        }

        private async Task<Unit> CheckIfTaken(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var similar = await _dbContext.Users
                .FirstOrDefaultAsync(value => value.Email == request.Email ||
                    value.Name == request.Name, cancellationToken);
            if (similar != null)
                throw new HasTakenException((similar.Email == request.Email) ? "Email" : "Username");
            return Unit.Value;
        }
    }
}
