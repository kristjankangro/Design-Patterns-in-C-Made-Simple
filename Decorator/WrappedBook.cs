using Demo.Common;

namespace Demo.Clip01;

class WrappedBook : Book
{
    private readonly Size packageSize = new Size(7 * Length.Millimeter);
    public WrappedBook(Book book) : base(book)
    {
    }

    public override Size GetDimensions(Size adSize) =>
        base.GetDimensions(adSize).Add(packageSize);
}