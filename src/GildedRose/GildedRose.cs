using GildedRose.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        private readonly IHandlerBuilder _handlerBuilder;

        public GildedRose(IList<Item> items, IHandlerBuilder handlerBuilder)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
            _handlerBuilder = handlerBuilder;
        }

        public void UpdateQuality()
        {
            var itemHandlers = _handlerBuilder
                     .WithAgedBrieHandler()
                     .WithBackstagePassHandler()
                     .WithSulfurasPassHandler()
                     .WithConjuredItemHandler()
                     .Build();

            foreach (var item in _items)
            {
                var itemAdapter = new ItemAdapter(item);

                var handler = itemHandlers.FirstOrDefault(x => x.CanHandle(itemAdapter));

                handler.Handle(itemAdapter);
            }
        }
    }
}
