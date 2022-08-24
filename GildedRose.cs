using csharp.Implementation;
using csharp.Interface;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        private readonly IUpdateQuality agedBrie;
        private readonly IUpdateQuality backstagePasses;
        private readonly IUpdateQuality sulfuras;
        private readonly IUpdateQuality normal;
        private readonly IUpdateQuality conjuredManaCake;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            agedBrie = new AgedBrie();
            backstagePasses = new BackstagePasses();
            sulfuras = new Sulfuras();
            normal = new Normal();
            conjuredManaCake = new ConjuredManaCake();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case Type.AGED_BRIE:
                        agedBrie.UpdateQuality(item);
                        continue;

                    case Type.BACKSTAGE_PASSES:
                        backstagePasses.UpdateQuality(item);
                        continue;

                    case Type.SULFURUS:
                        sulfuras.UpdateQuality(item);
                        continue;

                    case Type.CONJURED_MANA_CAKE:
                        conjuredManaCake.UpdateQuality(item);
                        continue;

                    default:
                        normal.UpdateQuality(item);
                        continue;
                }
            }
        }
    }
}
