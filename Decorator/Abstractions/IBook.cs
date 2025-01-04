using FluentBuilder.Common;

namespace FluentBuilder.Clip01
{
    public interface IBook
    {
        string Title { get; }
        Size GetDimensions(Size adPapersHeight);
    }
}
