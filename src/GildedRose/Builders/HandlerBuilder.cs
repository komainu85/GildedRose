using System.Collections.Generic;
using System.Linq;
using GildedRose.ItemHandlers;

namespace GildedRose.Builders
{
    public class HandlerBuilder : IHandlerBuilder
    {
        private readonly List<IItemHandler> _itemHandlers = new List<IItemHandler>();

        public HandlerBuilder WithAgedBrieHandler()
        {
            _itemHandlers.Add(new AgedBrieHandler());
            return this;
        }

        public HandlerBuilder WithBackstagePassHandler()
        {
            _itemHandlers.Add(new BackstagePassHandler());
            return this;
        }

        public HandlerBuilder WithSulfurasPassHandler()
        {
            _itemHandlers.Add(new SulfurasPassHandler());
            return this;
        }

        public HandlerBuilder WithConjuredItemHandler()
        {
            _itemHandlers.Add(new ConjuredItemHandler());
            return this;
        }

        public List<IItemHandler> Build() =>
             _itemHandlers.Append(new StandardItemHandler()).ToList();
    }
}
