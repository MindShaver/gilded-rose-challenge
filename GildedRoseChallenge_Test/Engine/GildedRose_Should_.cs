using System.Collections.Generic;
using System.Linq;
using GildedRoseChallenge.Engine;
using Xunit;

namespace GildedRoseChallenge_Test.Engine
{
    public class GildedRose_Should_
    {
        [Fact]
        public void Update_The_Quality_Of_Finely_Aged_Brie_To_Increase_With_Time()
        {
            var testQuality = 10;
            var expectedQuality = testQuality + 2;
            var testItem = new Item
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
        public void Update_The_Quality_Of_Regular_Aged_Brie_To_Increase_With_Time()
        {
            var testQuality = 10;
            var expectedQuality = testQuality + 1;
            var testItem = new Item
            {
                Name = "Aged Brie",
                Quality = testQuality,
                SellIn = 1
            };

            var items = new List<Item> { testItem };

            var engine = new GildedRose(items);
            engine.UpdateQuality();

            var actualQuality = items.First().Quality;

            Assert.Equal(expectedQuality, actualQuality);
        }
        
        [Fact]
        public void Decrease_Quality_Of_Standard_Non_Expired_Item_With_Time()
        {
            var testQuality = 10;
            var expectedQuality = testQuality - 1;
            var testItem = new Item
            {
                Name = "Not Aged Brie",
                Quality = testQuality,
                SellIn = 1
            };

            var items = new List<Item> { testItem };

            var engine = new GildedRose(items);
            engine.UpdateQuality();

            var actualQuality = items.First().Quality;

            Assert.Equal(expectedQuality, actualQuality);
        }
        
        [Fact]
        public void Decrease_Quality_Of_Standard_Expired_Item_With_Time()
        {
            var testQuality = 10;
            var expectedQuality = testQuality - 2;
            var testItem = new Item
            {
                Name = "Not Aged Brie",
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
        public void Not_Increase_Aged_Brie_Quality_Above_Fifty()
        {
            var testQuality = 50;
            var testItem = new Item
            {
                Name = "Aged Brie",
                Quality = testQuality,
                SellIn = 0
            };

            var items = new List<Item> { testItem };

            var engine = new GildedRose(items);
            engine.UpdateQuality();

            var actualQuality = items.First().Quality;

            Assert.Equal(50, actualQuality);
        }
        
        [Fact]
        public void Not_Decrease_Quality_Below_Zero()
        {
            var testQuality = 0;
            var testItem = new Item
            {
                Name = "Not Aged Brie",
                Quality = testQuality,
                SellIn = 0
            };

            var items = new List<Item> { testItem };

            var engine = new GildedRose(items);
            engine.UpdateQuality();

            var actualQuality = items.First().Quality;

            Assert.Equal(0, actualQuality);
        }
        
        [Fact]
        public void Maintain_Quality_For_Sulfuras()
        {
            var testQuality = 80;
            var testItem = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = testQuality,
                SellIn = 1
            };

            var items = new List<Item> { testItem };

            var engine = new GildedRose(items);
            engine.UpdateQuality();

            var actualQuality = items.First().Quality;

            Assert.Equal(80, actualQuality);
        }
        
        [Fact]
        public void Increase_Backstage_Pass_Quality_By_One_When_Concert_Date_Is_Above_Ten()
        {
            var testQuality = 10;
            var expectedQuality = testQuality + 1;
            var testItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = testQuality,
                SellIn = 20
            };

            var items = new List<Item> { testItem };

            var engine = new GildedRose(items);
            engine.UpdateQuality();

            var actualQuality = items.First().Quality;

            Assert.Equal(expectedQuality, actualQuality);
        }
        
        [Fact]
        public void Increase_Backstage_Pass_Quality_By_Two_When_Concert_Date_Is_Below_Eleven_Above_Six()
        {
            var testQuality = 10;
            var expectedQuality = testQuality + 2;
            var testItem = new Item
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
        }
        
        [Fact]
        public void Increase_Backstage_Pass_Quality_By_Three_When_Concert_Date_Is_Below_Six()
        {
            var testQuality = 10;
            var expectedQuality = testQuality + 3;
            var testItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = testQuality,
                SellIn = 5
            };

            var items = new List<Item> { testItem };

            var engine = new GildedRose(items);
            engine.UpdateQuality();

            var actualQuality = items.First().Quality;

            Assert.Equal(expectedQuality, actualQuality);
        }
        
        [Fact]
        public void Decrease_Backstage_Pass_Quality_To_Zero_After_Concert()
        {
            var testQuality = 10;
            var expectedQuality = 0;
            var testItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
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
