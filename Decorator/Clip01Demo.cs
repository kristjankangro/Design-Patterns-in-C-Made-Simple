using Demo.Common;

namespace Demo.Clip01
{
    class Clip01Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 1;
        private readonly Length mm = Length.Millimeter;

        protected override void Implementation()
        {
            var book = new Book("Title",
                new Size(188 * mm, 239 * mm, 28 * mm));
            var customer = new Buyer();
            customer.Handle(book);

            var employee = new Dispatcher();
            employee.Handle(book);

        }
    }
}
