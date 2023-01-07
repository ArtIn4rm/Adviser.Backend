using MediatR;

namespace Adviser.Application.CQRS.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public string? Name { get; set; }

        public Guid NameOfSubject { get; set; }

        public int GroupId { get; set; }

        public string? MarkdownContent { get; set; }

        public float AuthorMark { get; set; }

        public Guid WallpaperId { get; set; }
    }
}
