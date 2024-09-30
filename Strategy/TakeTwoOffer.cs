using Strategy;

namespace Demo.Clip01
{
    public class TakeTwoOffer
    {
        private Book First { get; }
        private Book Second { get; }

        public TakeTwoOffer(Book first, Book second)
        {
            this.First = first;
            this.Second = second;
        }

        public (Book first, Book second) Apply() => (this.First, this.Second);
    }
}