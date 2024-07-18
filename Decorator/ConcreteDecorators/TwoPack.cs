using Demo.Common;

namespace Demo.Clip01;

class TwoPack : BaseBookDecorator
{
    public TwoPack(IBook book) : base(book) {}
    public override Size GetDimensions(Size adPapersHeight)
    {
        return base.GetDimensions(Size.Zero)
            .ScaleHeight(2)
            .AddToTop(adPapersHeight);
    }
}