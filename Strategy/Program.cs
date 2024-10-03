using System.Globalization;
using Strategy;
using Strategy.Common;
using Strategy.Modifiers;
using Strategy.Modifiers.Deduction;

var priceModifiers = new List<IPriceModifier>()
{
    new GetSecondFree(),
    new FromSecond(new Absolute(DeductionRepo.Get(7))),
    new FromSecondWithSpillover(new Absolute(DeductionRepo.Get(12))),
    new FromSecondWithSpillover(new RelativeToTotal(.1M)),
    new FromSecondWithSpillover(new RelativeToTotal(.25M)),
    new Proportional(new Absolute(DeductionRepo.Get(12))),
    
};

// foreach (var priceModifier in priceModifiers) 
    // OfferCart.Apply(new TakeTwoOffer(priceModifier));
    
// mod 18 .net strategies
HashSet<Book> books = new HashSet<Book>(new BookTitleComparer());

SortedList<string, Book> sorted = new SortedList<string, Book>(
    StringComparer.Create(CultureInfo.GetCultureInfo("de-DE"), true));

var book = Books.GetBooks().first;
sorted.Add(book.Title, book);

IEnumerable<Book> sequence = new Book[] { book };
IEnumerable<Book> results = sequence.Where(book => book.Price <= new Money(29, book.Price.Currency))
    .OrderBy(book => book.Title, StringComparer.Create(CultureInfo.GetCultureInfo("et-ET"), true ));
