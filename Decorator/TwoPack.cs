using Demo.Common;

namespace Demo.Clip01;

abstract class BookDecorator : IBook
{

    private IBook Target;
    protected BookDecorator(IBook target)
    {
        Target = target;
    }

    public virtual string Title => Target.Title;

    public virtual Size GetDimensions(Size adPapersHeight)
    {
        return Target.GetDimensions(adPapersHeight);
    }
}

class TwoPack : BookDecorator
{
    public TwoPack(IBook book) : base(book) {}
    public override Size GetDimensions(Size adPapersHeight)
    {
        return base.GetDimensions(Size.Zero)
            .ScaleHeight(2)
            .AddToTop(adPapersHeight);
    }
}