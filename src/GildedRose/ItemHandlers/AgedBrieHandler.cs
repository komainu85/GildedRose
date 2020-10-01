namespace GildedRose.ItemHandlers
{
    public class AgedBrieHandler : IItemHandler
    {
        public bool CanHandle(ItemAdapter item) => item.Name.Equals("Aged Brie");

        public void Handle(ItemAdapter item)
        {
            item.IncrementQuality();

            item.DecrementSellin();

            if (item.SellIn < 0)
            {
                item.IncrementQuality();
            }
        }
    }
}
