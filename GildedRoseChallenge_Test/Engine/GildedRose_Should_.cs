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
        [Fact]
        public void Update_The_Quality_Of_Backstage_Pass_To_Change_With_Time()
        {
            int testQuality = 10;
            var expectedQuality = testQuality + 2;
            var expectedQuality2 = testQuality + 13;
            Item testItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = testQuality,
                SellIn = 10
            };

            var items = new List<Item> { testItem };

            var engine = new GildedRose(items);
            engine.UpdateQuality();

            var actualQuality = items.First().Quality;

            Assert.Equal(expectedQuality, actualQuality);

            while (items.First().SellIn > 4)
            {
                engine.UpdateQuality();
            }

            var actualQuality2 = items.First().Quality;
            
            Assert.Equal(expectedQuality2, actualQuality2);
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
