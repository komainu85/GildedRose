using System;

namespace GildedRose
{
    public class ItemAdapter
    {
        private readonly Item _item;

        public ItemAdapter(Item item)
        {
            _item = item ?? throw new ArgumentNullException(nameof(item));
        }

        public string Name => _item.Name;
        public int Quality => _item.Quality;
        public int SellIn => _item.SellIn;

        public void IncrementQuality()
        {
            if (_item.Quality < 50)
            {
                _item.Quality++;
            }
        }

        public void SetQualityToZero() =>
            _item.Quality -= _item.Quality;

        public void DecrementSellin() =>
            _item.SellIn--;

        public void DecrementQuality()
        {
            if (_item.Quality > 0)
            {
                _item.Quality--;
            }
        }
    }
}