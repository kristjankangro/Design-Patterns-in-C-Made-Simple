using Strategy.Common;

namespace Strategy;

public class DeductionRepo
{
    //in real app, comes from db configurable field monthly special offer etc
    public static Money Get7() => new(7, new Currency("USD"));
    public static Money Get12() => new(12, new Currency("USD"));
}