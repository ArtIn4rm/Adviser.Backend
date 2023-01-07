using Adviser.Application.Interfaces;
using Adviser.Domain;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Adviser.Application.Common.Exceptions;

namespace Adviser.Application.CQRS.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Guid>
    {
        private readonly IDbContext _dbContext;

        public CreateReviewCommandHandler(IDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Name = request.Name,
                NameOfSubject = request.NameOfSubject,
                GroupId = (Group)request.GroupId,
                MarkdownContent = request.MarkdownContent,
                AuthorMark = request.AuthorMark,
                Wallpaper = request.WallpaperId.ToString(),
                AddingTime = DateTime.Now
            };
            await CheckIfReviewAlreadyWritten(request, cancellationToken);
            await _dbContext.Reviews.AddAsync(review, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return review.Id;
        }

        private async Task<Unit> CheckIfReviewAlreadyWritten(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var similar = await _dbContext.Reviews
                .FirstOrDefaultAsync(value => value.UserId == request.UserId &&
                    value.NameOfSubject == request.NameOfSubject, cancellationToken);
            if (similar != null)
                throw new HasBeenReviewedException();
            return Unit.Value;
        }
    }
}
