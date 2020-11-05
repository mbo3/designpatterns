namespace Builder.OrderBuilder
{
    class InheritedFluentSpecialOrderBuilder<Self> 
        : GenericFluentOrderBuilder<InheritedFluentSpecialOrderBuilder<Self>> 
        where Self : InheritedFluentSpecialOrderBuilder<Self>
    {
        public Self IsSpecial()
        {
            order.SpecialOrder = true;
            return (Self)this;
        }
    }
}
