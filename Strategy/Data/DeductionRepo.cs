using Strategy.Common;

namespace Strategy;

public class DeductionRepo
{
    //in real app, comes from db configurable field monthly special offer etc
    public static Money Get(int amount) => new(amount, new Currency("USD"));
}