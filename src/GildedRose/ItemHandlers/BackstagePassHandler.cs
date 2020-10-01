namespace GildedRose.ItemHandlers
{
    public class BackstagePassHandler : IItemHandler
    {
        public bool CanHandle(ItemAdapter item) => item.Name.Equals("Backstage passes to a TAFKAL80ETC concert");

        public void Handle(ItemAdapter item)
        {
            item.IncrementQuality();

            if (item.SellIn < 11)
            {
                item.IncrementQuality();
            }

            if (item.SellIn < 6)
            {
                item.IncrementQuality();
            }

            if (item.SellIn < 0)
            {
                item.SetQualityToZero();
            }

            item.DecrementSellin();
        }
    }
}
