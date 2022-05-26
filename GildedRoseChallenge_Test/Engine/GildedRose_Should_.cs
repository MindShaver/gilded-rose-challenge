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
        [Fact]  
        public void Update_The_Quality_Of_An_Item_To_Decrease_With_Time()  
        {  
            var testQuality = 10;  
            var expectedQuality = testQuality - 1;  
            var testSellin = 10;  
            var expectedSellin = testSellin - 1;  
      
            Item testItem = new Item  
            {  
                Name = "Basic Item",  
                Quality = testQuality,  
                SellIn = testSellin  
            };  
  
            var items = new List<Item> { testItem };  
  
            var engine = new GildedRose(items);  
            engine.UpdateQuality();  
  
            var actualQuality = items.First().Quality;  
            var actualSellin = items.First().SellIn;  
  
            Assert.Equal(expectedQuality, actualQuality);  
            Assert.Equal(expectedSellin, actualSellin);  
        }
    }
}
