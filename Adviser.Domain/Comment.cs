
namespace Adviser.Domain
{
    public class Comment
    {
        public Guid UserId { get; set; }

        public Guid ReviewId { get; set; }

        public DateTime AddingTime { get; set; }

        public string? CommentText { get; set; }
    }
}
