using Builder.Models;

namespace Builder.OrderBuilder
{
    sealed class FunctionalOrderBuilder : FunctionalBuilder<Order, FunctionalOrderBuilder>
    {
        public FunctionalOrderBuilder Number(int number)
        {
            return Do(o => o.Number = number);
        }
    }
}
