namespace GildedRose.ItemHandlers
{
    public class StandardItemHandler : IItemHandler
    {
        public bool CanHandle(ItemAdapter item) => true;

        public void Handle(ItemAdapter item)
        {
            item.DecrementQuality();

            item.DecrementSellin();

            if (item.SellIn < 0)
            {
                item.DecrementQuality();
            }
        }
    }
}
