
using System.Text.RegularExpressions;

namespace Adviser.Domain
{
    public class Subject
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public Group GroupId { get; set; }

        public float Mark { get; set; }

        public int MarksCount { get; set; }

        public DateTime AddingTime { get; set; }
    }

    public enum Group
    {
        Movie,
        Game
    }
}
