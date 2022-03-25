using GildedRoseChallenge;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRoseChallenge_Test.Engine
{
    public class GildedRose_Should_
    {
        [Fact]
        public void Update_The_Quality_Of_Aged_Brie_To_Increase_With_Time()
        {
            var testQuality = 10;
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

            Assert.Equal(expectedQuality + 1, actualQuality);
        }
    }
}
