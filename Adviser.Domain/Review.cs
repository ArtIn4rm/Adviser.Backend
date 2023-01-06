
namespace Adviser.Domain
{
    public class Review
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string? Name { get; set; }

        public Guid NameOfSubject { get; set; }

        public Group GroupId { get; set; }

        public string? MarkdownContent { get; set; }

        public float AuthorMark { get; set; }

        public string? Wallpaper { get; set; }

        public DateTime AddingTime { get; set; }
    }
}
