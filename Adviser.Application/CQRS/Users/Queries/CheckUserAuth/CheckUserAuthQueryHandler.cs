using MediatR;
using Microsoft.EntityFrameworkCore;
using Adviser.Application.Common.Exceptions;
using Adviser.Application.Interfaces;

namespace Adviser.Application.CQRS.Users.Queries.CheckUserAuth
{
    public class CheckUserAuthQueryHandler : IRequest<CheckUserAuthQuery>
    {
        private readonly IDbContext _dbContext;

        public CheckUserAuthQueryHandler(IDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(CheckUserAuthQuery request,
           CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(value => value.Id == request.Id, cancellationToken);
            if (user == null || user.Id != request.Id)
                throw new InvalidTokenException();
            return Unit.Value;
        }
    }
}
