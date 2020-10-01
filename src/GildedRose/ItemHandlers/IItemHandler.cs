namespace GildedRose.ItemHandlers
{
    public interface IItemHandler
    {
        bool CanHandle(ItemAdapter item);
        void Handle(ItemAdapter item);
    }
}