using Strategy.Common;

namespace Strategy;

public class Deduction
{
    //in real app, comes from db configurable field monthly special offer etc
    public static Money GetActive() => new(7, new Currency("USD"));
}