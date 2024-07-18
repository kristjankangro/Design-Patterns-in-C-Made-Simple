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

        public virtual Size GetDimensions(Size adPapersHeight) => Dimensions.AddToTop(adPapersHeight);
        public override string ToString() =>
            $"{this.Title} - {this.Dimensions}";
    }

    public class TwoPack : Book
    {
        public TwoPack(Book book) : base(book)
        {
        }

        public override Size GetDimensions(Size adPapersHeight)
        {
            return base.GetDimensions(Size.Zero)
                .ScaleHeight(2)
                .AddToTop(adPapersHeight);
        }
    }
}
