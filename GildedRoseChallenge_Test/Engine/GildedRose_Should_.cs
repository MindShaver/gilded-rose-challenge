using GildedRoseChallenge;
using System.Collections.Generic;
using System.Linq;
using GildedRoseChallenge.Engine;
using Xunit;

namespace GildedRoseChallenge_Test.Engine
{
    public class GildedRose_Should_
    {
        [Fact]
        public void Update_The_Quality_Of_Aged_Brie_To_Increase_With_Time()
        {
            const int testQuality = 10;
            var expectedQuality = testQuality + 1;
            Item testItem = new Item
            {
                Name = "Aged Brie",
                Quality = testQuality,
                SellIn = 0
            };

            var items = new List<Item> { testItem };

            var engine = new GildedRose(items);
            engine.UpdateQuality();

            var actualQuality = items.First().Quality;

            Assert.Equal(expectedQuality, actualQuality);
        }

        [Theory]
        [InlineData(10, 11, 11)]
        [InlineData(10, 10, 12)]
        [InlineData(10, 5, 13)]
        [InlineData(10, -1, 0)]
        [InlineData(0, 10, 2)]
        [InlineData(0, 5, 3)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 11, 1)]
        public void Update_The_Quality_Of_Backstage_Pass_To_Change_With_Time(int testQuality, int sellIn, int expectedQuality)
        {
            Item testItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = testQuality,
                SellIn = sellIn
            };

            var items = new List<Item> { testItem };

            var engine = new GildedRose(items);
            engine.UpdateQuality();

            var actualQuality = items.First().Quality;

            Assert.Equal(expectedQuality, actualQuality);
        }

        [Theory]
        [InlineData(10, 10, 9)]
        [InlineData(0, 10, 0)]
        public void Update_The_Quality_Of_Normal_Item_To_Decrease_With_Time(int testQuality, int sellIn, int expectedQuality)
        {
            Item testItem = new Item
            {
                Name = "Normal Item",
                Quality = testQuality,
                SellIn = sellIn
            };

            var items = new List<Item> { testItem };

            var engine = new GildedRose(items);
            engine.UpdateQuality();

            var actualQuality = items.First().Quality;

            Assert.Equal(expectedQuality, actualQuality);
        }

        [Fact]
        public void Not_Update_The_Quality_Of_Sulfuras_To_Increase_With_Time()
        {
            var testQuality = 10;
            var expectedQuality = 10;
            Item testItem = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = testQuality,
                SellIn = 0
            };

            var items = new List<Item> { testItem };

            var engine = new GildedRose(items);
            engine.UpdateQuality();

            var actualQuality = items.First().Quality;

            Assert.Equal(expectedQuality, actualQuality);
        }
    }
}
