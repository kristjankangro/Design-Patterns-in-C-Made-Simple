using Strategy;
using Strategy.Common;

public class InvoicePrinter
{
    public void PrintInvoiceFor(Book product, decimal taxRate, Func<Currency, Money> packagingCalc)
    {
        WriteLine(product.Title, product.Price);
        Money tax = product.Price * taxRate;
        WriteLine("Tax", tax);

        var packagingCost = packagingCalc(product.Price.Currency);
        WriteLine("Packaging", packagingCost);
        Money total = product.Price + tax + packagingCost;
        WriteSeparator();
        WriteLine("Total", total);
        WriteEnd();
    }    
    void WriteSeparator()
    {
        Console.WriteLine($"{new string('_', 41)}");
    }
    void WriteEnd()
    {
        Console.WriteLine($"{new string('#', 41)}{Environment.NewLine}{Environment.NewLine}");
    }
    void WriteLine(string key, Money money)
    {
        Console.WriteLine($"{key}{" ".PadRight(30, '.')}{money,10}");
    }
}