namespace GildedRose.ItemHandlers
{
    public class ConjuredItemHandler : IItemHandler
    {
        public bool CanHandle(ItemAdapter item) => item.Name.Equals("Conjured Mana Cake");

        public void Handle(ItemAdapter item)
        {
            item.DecrementQuality();
            item.DecrementQuality();

            item.DecrementSellin();

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.DecrementQuality();
                item.DecrementQuality();
            }
        }
    }
}
