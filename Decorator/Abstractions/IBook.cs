using Demo.Common;

namespace Demo.Clip01
{
    public interface IBook
    {
        string Title { get; }
        Size GetDimensions(Size adPapersHeight);
    }
}
