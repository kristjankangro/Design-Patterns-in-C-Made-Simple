using Strategy.Common;

namespace Strategy;

public class Deduction
{
    public static Money GetActive()
    {
        return new Money(7, new Currency("USD"));
    }
}