using System;
using System.Collections.Generic;
using System.Linq;

namespace Builder.OrderBuilder
{
    abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {
        private readonly List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();

        private TSelf AddAction(Action<TSubject> action)
        {
            actions.Add((x) =>
            {
                action(x);
                return x;
            });

            return (TSelf)this;
        }

        public TSelf Do(Action<TSubject> action)
        {
            return AddAction(action);
        }

        public TSubject Build()
        {
            return actions.Aggregate(new TSubject(), (x, y) => y(x));
        }
    }
}
