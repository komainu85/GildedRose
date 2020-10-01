namespace GildedRose.ItemHandlers
{
    public class SulfurasPassHandler : IItemHandler
    {
        public bool CanHandle(ItemAdapter item) => item.Name.Equals("Sulfuras, Hand of Ragnaros");

        public void Handle(ItemAdapter item)
        {
            item.IncrementQuality();
        }
    }
}
