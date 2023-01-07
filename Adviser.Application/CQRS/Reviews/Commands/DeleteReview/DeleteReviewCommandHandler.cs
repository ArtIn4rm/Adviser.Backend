using Adviser.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Adviser.Application.Common.Exceptions;
using Adviser.Domain;

namespace Adviser.Application.CQRS.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
    {
        private readonly IDbContext _dbContext;

        public DeleteReviewCommandHandler(IDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _dbContext.Reviews
                .FirstOrDefaultAsync(value => value.Id == request.Id, cancellationToken);
            if (review == null)
                throw new NotFoundException(nameof(Review), request.Id);
            _dbContext.Reviews.Remove(review);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
