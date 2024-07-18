using Demo.Common;

namespace Demo.Clip01;

class PrintedBook : IBook {
    public string Title { get; }
    public virtual Size Dimensions { get; }

    public PrintedBook(string title, Size dimensions)
    {
        this.Title = title;
        this.Dimensions = dimensions;
    }


    public Size GetDimensions(Size adPapersHeight) => Dimensions.AddToTop(adPapersHeight);
    public override string ToString() =>
        $"{this.Title} - {this.Dimensions}";
}