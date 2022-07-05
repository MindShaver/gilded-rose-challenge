using System;
using GildedRoseChallenge;
using System.Collections.Generic;
using System.Linq;
using GildedRoseChallenge.Engine;
using Xunit;
using Xunit.Abstractions;

namespace GildedRoseChallenge_Test.Engine
{
    public class GildedRose_Should_
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public GildedRose_Should_(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(50, 11, 50)]
        [InlineData(10, -1, 12)]
        [InlineData(10, 1, 11)]
        public void Update_The_Quality_Of_Aged_Brie_To_Increase_With_Time(int testQuality, int sellIn, int expectedQuality)
        {
            Item testItem = new Item
            {
                Name = "Aged Brie",
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
        [InlineData(10, 11, 11)]
        [InlineData(10, 10, 12)]
        [InlineData(10, 5, 13)]
        [InlineData(10, -1, 0)]
        [InlineData(0, 10, 2)]
        [InlineData(0, 5, 3)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 11, 1)]
        [InlineData(50, 10, 50)]
        public void Update_The_Quality_Of_Backstage_Pass_To_Change_With_Time(int testQuality, int sellIn, int expectedQuality)
        {
            Item testItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = testQuality,
                SellIn = sellIn
            };
            _testOutputHelper.WriteLine(testItem.Name[0].ToString());
            var items = new List<Item> { testItem };

            var engine = new GildedRose(items);
            engine.UpdateQuality();

            var actualQuality = items.First().Quality;

            Assert.Equal(expectedQuality, actualQuality);
        }

        [Theory]
        [InlineData(10, 10, 9)]
        [InlineData(0, 10, 0)]
        [InlineData(10, -1, 8)]
        public void Update_The_Quality_Of_Normal_Item_To_Decrease_With_Time(int testQuality, int sellIn,
            int expectedQuality)
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
        
        [Theory]
        [InlineData("[Conjured] Normal item", 10, 10, 8)]
        [InlineData("[Conjured] Normal item", -456, 1, 0)]
        [InlineData("[Conjured] Normal item", 10, -1, 6)]
        [InlineData("[Conjured] Backstage passes to a TAFKAL80ETC concert", 10, 11, 12)]
        [InlineData("[Conjured] Backstage passes to a TAFKAL80ETC concert", 10, 10, 14)]
        [InlineData("[Conjured] Backstage passes to a TAFKAL80ETC concert", 10, 5, 16)]
        [InlineData("[Conjured] Backstage passes to a TAFKAL80ETC concert", 10, -1, 0)]
        [InlineData("[Conjured] Backstage passes to a TAFKAL80ETC concert", -456, 1, 0)]
        [InlineData("[Conjured] Sulfuras, Hand of Ragnaros", 80, 10, 80)]
        [InlineData("[Conjured] Aged Brie", 50, 11, 50)]
        [InlineData("[Conjured] Aged Brie", 10, -1, 14)]
        [InlineData("[Conjured] Aged Brie", 10, 1, 12)]
        [InlineData("[Conjured] Aged Brie", -456, 1, 0)]
        public void Update_The_Quality_Of_Conjured_Item_To_Change_With_Time(String itemName, int testQuality, int sellIn,
            int expectedQuality)
        {
            Item testItem = new Item
            {
                Name = itemName,
                Quality = testQuality,
                SellIn = sellIn
            };
            
            _testOutputHelper.WriteLine(testItem.Name[0].ToString());

            var items = new List<Item> { testItem };

            var engine = new GildedRose(items);
            engine.UpdateQuality();

            var actualQuality = items.First().Quality;

            Assert.Equal(expectedQuality, actualQuality);
        }

        [Fact]
        public void Not_Update_The_Quality_Of_Sulfuras_To_Increase_With_Time()
        {
            var testQuality = 80;
            var expectedQuality = 80;
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
