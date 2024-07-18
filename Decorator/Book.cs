using Demo.Common;

namespace Demo.Clip01
{
    public class Book
    {
        public string Title { get; }
        public virtual Size Dimensions { get; }

        public Book(string title, Size dimensions)
        {
            this.Title = title;
            this.Dimensions = dimensions;
        }

        protected Book(Book book) : this(book.Title, book.Dimensions){}
        public override string ToString() =>
            $"{this.Title} - {this.Dimensions}";
    }
    
    class WrappedBook : Book
    {
        private readonly Size packageSize = new Size(7 * Length.Millimeter);
        public WrappedBook(Book book) : base(book)
        {
        }

        public override Size Dimensions => base.Dimensions.Add(
            packageSize);
    }
}
