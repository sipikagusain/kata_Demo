using csharp.Interface;

namespace csharp.Implementation
{
    internal class Normal : IUpdateQuality
    {
        public void UpdateQuality(Item item)
        {
            Update(item);
        }

        private static void Update(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }
    }
}
