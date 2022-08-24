using csharp.Interface;

namespace csharp.Implementation
{
    internal class ConjuredManaCake : IUpdateQuality
    {
        public void UpdateQuality(Item item)
        {
            Update(item);
        }

        private static void Update(Item item)
        {
            if (item.Quality > 1)
            {
                item.Quality = item.Quality - 2;
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0 && item.Quality > 1)
            {
                item.Quality = item.Quality - 2;
            }
        }
    }
}
