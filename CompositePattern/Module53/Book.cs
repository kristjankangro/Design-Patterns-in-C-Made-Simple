using CompositePattern.Module53;

namespace Demo.Clip06
{
    public class Book
    {
        public string Title { get; }
        public Name Author { get; }
        public Volume Volumes { get; }

        public Book(string title, Name author, Volume volumes)
        {
            this.Title = title;
            this.Author = author;
            Volumes = volumes;
        }

        public override string ToString() =>
            $"{this.Author.Printable}, {this.Title}{this.Volumes.GetLabel(" (Vol.", ")")}";
    }
}
