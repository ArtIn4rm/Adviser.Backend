using MediatR;

namespace Adviser.Application.CQRS.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
