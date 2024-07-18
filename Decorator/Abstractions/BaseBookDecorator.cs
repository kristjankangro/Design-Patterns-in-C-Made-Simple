using Demo.Common;

namespace Demo.Clip01;

abstract class BaseBookDecorator : IBook
{

    private IBook Target;
    protected BaseBookDecorator(IBook target)
    {
        Target = target;
    }

    public virtual string Title => Target.Title;

    public virtual Size GetDimensions(Size adPapersHeight)
    {
        return Target.GetDimensions(adPapersHeight);
    }
}