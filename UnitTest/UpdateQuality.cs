using csharp;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseTests
{
    public class Tests
    {
        private GildedRose? gildedRose;


        [Test]
        public void GildedRoseTests_UpdateQuality_Should_Work_For_Sulfuras()
        {
            IList<Item> items = new List<Item>
            {
              new Item {Name = Type.SULFURUS, SellIn = 15, Quality = 40},
              new Item {Name = Type.SULFURUS, SellIn = 30, Quality = 20},
              new Item {Name = Type.SULFURUS, SellIn = 20, Quality = 45}
            };

            gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.AreEqual(items?.FirstOrDefault()?.SellIn, 15, "Sell is same");
            Assert.AreEqual(items?.FirstOrDefault()?.Quality, 40, "Quality is same");
            Assert.AreEqual(items?.Last()?.SellIn, 20, "Sell is same");
            Assert.AreEqual(items?.Last()?.Quality, 45, "Quality is same");
        }

        [Test]
        public void GildedRoseTests_UpdateQuality_Should_Work_For_AgedBrie()
        {
            IList<Item> items = new List<Item>
            {
              new Item {Name = Type.AGED_BRIE, SellIn = 15, Quality = 23},
              new Item {Name = Type.AGED_BRIE, SellIn = 10, Quality = 50},
              new Item {Name = Type.AGED_BRIE, SellIn = -2, Quality = 49},
            };

            gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.AreEqual(items?.FirstOrDefault()?.SellIn, 14, "Sell is correct");
            Assert.AreEqual(items?.FirstOrDefault()?.Quality, 24, "Quality is correct");
            Assert.AreEqual(items?.Last()?.SellIn, -3, "Sell is correct");
            Assert.AreEqual(items?.Last()?.Quality, 50, "Quality is correct");
            Assert.AreEqual(items?.Skip(1).First()?.Quality, 50, "Quality is correct and it is never more than 50");
        }

        [Test]
        public void GildedRoseTests_UpdateQuality_Should_Work_For_BackStagePasses()
        {
            IList<Item> items = new List<Item>
            {
              new Item {Name = Type.BACKSTAGE_PASSES, SellIn = 23, Quality = 46},
              new Item {Name = Type.BACKSTAGE_PASSES, SellIn = 7, Quality = 25},
              new Item {Name = Type.BACKSTAGE_PASSES, SellIn = 15, Quality = 50},
              new Item {Name = Type.BACKSTAGE_PASSES, SellIn = 0, Quality = 50},
              new Item {Name = Type.BACKSTAGE_PASSES, SellIn = 5, Quality = 34},
            };

            gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.AreEqual(items?.FirstOrDefault()?.SellIn, 22, "Sell is correct");
            Assert.AreEqual(items?.FirstOrDefault()?.Quality, 47, "Quality is correct");
            Assert.AreEqual(items?.Skip(1).FirstOrDefault()?.SellIn, 6, "Sell is correct");
            Assert.AreEqual(items?.Skip(1).First()?.Quality, 27, "Quality is correct and increased by 2 for 7 days");
            Assert.AreEqual(items?.Skip(2).FirstOrDefault()?.SellIn, 14, "Sell is correct");
            Assert.AreEqual(items?.Skip(2).First()?.Quality, 50, "Quality is correct and not more than 50");
            Assert.AreEqual(items?.Skip(3).FirstOrDefault()?.SellIn, -1, "Sell is correct");
            Assert.AreEqual(items?.Skip(3).First()?.Quality, 0, "Quality is correct and dropped to 0");
            Assert.AreEqual(items?.Last()?.SellIn, 4, "Sell is correct");
            Assert.AreEqual(items?.Last()?.Quality, 37, "Quality is correct and increased by 3 for 5 days");
        }

        [Test]
        public void GildedRoseTests_UpdateQuality_Should_Work_For_Normal_Update()
        {
            IList<Item> items = new List<Item>
            {
              new Item {Name = "Test", SellIn = 7, Quality = 46},
              new Item {Name = "Test123", SellIn = -2, Quality = 25},
              new Item {Name = "Test123", SellIn = 14, Quality = 0}
            };

            gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.AreEqual(items?.FirstOrDefault()?.SellIn, 6, "Sell is correct");
            Assert.AreEqual(items?.FirstOrDefault()?.Quality, 45, "Quality is correct");
            Assert.AreEqual(items?.Skip(1).FirstOrDefault()?.SellIn, -3, "Sell is correct");
            Assert.AreEqual(items?.Skip(1).First()?.Quality, 23, "Quality is correct and decreased by 2 as sell date is passed");
            Assert.AreEqual(items?.Skip(2).FirstOrDefault()?.SellIn, 13, "Sell is correct");
            Assert.AreEqual(items?.Skip(2).First()?.Quality, 0, "Quality is correct and cannot be negative");
        }

        [Test]
        public void GildedRoseTests_UpdateQuality_Should_Work_For_CONJURED_MANA_CAKE()
        {
            IList<Item> items = new List<Item>
            {
              new Item {Name = Type.CONJURED_MANA_CAKE, SellIn = 7, Quality = 46},
              new Item {Name = Type.CONJURED_MANA_CAKE, SellIn = -2, Quality = 25},
              new Item {Name = Type.CONJURED_MANA_CAKE, SellIn = 14, Quality = 0}
            };

            gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.AreEqual(items?.FirstOrDefault()?.SellIn, 6, "Sell is correct");
            Assert.AreEqual(items?.FirstOrDefault()?.Quality, 44, "Quality is correct");
            Assert.AreEqual(items?.Skip(1).FirstOrDefault()?.SellIn, -3, "Sell is correct");
            Assert.AreEqual(items?.Skip(1).First()?.Quality, 21, "Quality is correct and decreased by 4 as sell date is passed");
            Assert.AreEqual(items?.Skip(2).FirstOrDefault()?.SellIn, 13, "Sell is correct");
            Assert.AreEqual(items?.Skip(2).First()?.Quality, 0, "Quality is correct and cannot be negative");
        }
    }
}