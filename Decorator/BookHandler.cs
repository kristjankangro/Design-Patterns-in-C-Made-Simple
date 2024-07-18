using System;
using Demo.Common;

namespace Demo.Clip01
{
    class BookHandler
    {
        public void Handle(Book product)
        {
            var slimCd = new Size(142 * Length.Millimeter,
                125 * Length.Millimeter, 5 * Length.Millimeter
            );
            var bookSize = product.GetDimensions(slimCd);
            Console.WriteLine($"Handling book \"{product.Title}\" of size {bookSize}");
        }
    }
}
