using Adviser.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Adviser.Application.Common.Exceptions;
using Adviser.Domain;
using MediatR;
using Task4.Application.Common.Exceptions;

namespace Adviser.Application.CQRS.Users.Queries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, Guid>
    {
        private readonly IDbContext _dbContext;

        public LoginUserQueryHandler(IDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user =>
                user.Email == request.Email, cancellationToken);
            CheckQueryCorrectness(user, request, cancellationToken);
            return user!.Id;
        }

        private void CheckQueryCorrectness(User? user, LoginUserQuery request, CancellationToken cancellationToken)
        {
            if (user == null || user.Email != request.Email)
                throw new NotFoundException(nameof(User), request.Email!);
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new WrongPasswordException();
        }
    }
}
