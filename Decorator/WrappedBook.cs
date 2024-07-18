using Demo.Common;

namespace Demo.Clip01;

class WrappedBook : BookDecorator
{
    private readonly Size packageSize = new(7 * Length.Millimeter);
    public WrappedBook(IBook book) : base(book)
    {
    }

    public override Size GetDimensions(Size adSize) =>
        base.GetDimensions(adSize).Add(packageSize);
}