using System.Collections.Generic;
using GildedRose.ItemHandlers;

namespace GildedRose.Builders
{
    public interface IHandlerBuilder
    {
        HandlerBuilder WithAgedBrieHandler();
        HandlerBuilder WithBackstagePassHandler();
        HandlerBuilder WithSulfurasPassHandler();
        HandlerBuilder WithConjuredItemHandler();
        List<IItemHandler> Build();
    }
}