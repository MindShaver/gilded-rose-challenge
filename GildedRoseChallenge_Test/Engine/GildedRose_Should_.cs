using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GildedRoseChallenge.Engine;
using Xunit;

namespace GildedRoseChallenge_Test.Engine
{
    [ExcludeFromCodeCoverage]
    public class GildedRose_Should_
    {
        [Fact]
        public void Reduce_Item_Quality_By_1()
        {
            // Arrange 
            var testQuality = 10;
            var expectedQuality = testQuality - 1;

            Item testItem = new Item()
            {
                Name = "Common Item",
                Quality = testQuality,
                SellIn = 10
            };

            var items = new List<Item>() { testItem };

            var engine = new GildedRose(items);

            // Act

            engine.UpdateQuality();

            var actualQuality = items.First().Quality;


            // Assert

            Assert.Equal(expectedQuality, actualQuality);
        }

        [Fact]
        public void Reduce_Item_Quality_By_2_If_Past_Sellin_Date()
        {
            // Arrange 
            var testQuality = 10;
            var expectedQuality = testQuality - 2;

            Item testItem = new Item()
            {
                Name = "Common Item",
                Quality = testQuality,
                SellIn = -1
            };

            var items = new List<Item>() { testItem };

            var engine = new GildedRose(items);

            // Act

            engine.UpdateQuality();

            var actualQuality = items.First().Quality;


            // Assert

            Assert.Equal(expectedQuality, actualQuality);
        }

        [Fact]
        public void Update_Aged_Brie_To_Gain_1_Quality()
        {
            // Arrange 
            var testQuality = 10;
            var expectedQuality = testQuality + 1;

            Item testItem = new Item()
            {
                Name = "Aged Brie",
                Quality = testQuality,
                SellIn = 10
            };

            var items = new List<Item>() { testItem };

            var engine = new GildedRose(items);

            // Act

            engine.UpdateQuality();

            var actualQuality = items.First().Quality;


            // Assert

            Assert.Equal(expectedQuality, actualQuality);
        }

        [Fact]
        public void Update_Aged_Brie_To_Gain_2_Quality_If_Past_Sellin_Date()
        {
            // Arrange 
            var testQuality = 10;
            var expectedQuality = testQuality + 2;

            Item testItem = new Item()
            {
                Name = "Aged Brie",
                Quality = testQuality,
                SellIn = -1
            };

            var items = new List<Item>() { testItem };

            var engine = new GildedRose(items);

            // Act

            engine.UpdateQuality();

            var actualQuality = items.First().Quality;


            // Assert

            Assert.Equal(expectedQuality, actualQuality);
        }

        [Fact]
        public void Keep_Sulfuras_At_100_Sellin_And_80_Quality()
        {
            // Arrange 
            var testQuality = 80;
            var testSellin = 100;
            var expectedQuality = testQuality;
            var expectedSellin = testSellin;

            Item testItem = new Item()
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = testQuality,
                SellIn = testSellin
            };

            var items = new List<Item>() { testItem };

            var engine = new GildedRose(items);

            // Act

            engine.UpdateQuality();

            var actualQuality = items.First().Quality;
            var actualSellin = items.First().SellIn;


            // Assert

            Assert.Equal(expectedQuality, actualQuality);
            Assert.Equal(expectedSellin, actualSellin);
        }

        [Fact]
        public void Update_Concert_Tickets_To_Gain_2_Quality_When_Less_Than_11_Days()
        {
            var testQuality = 10;
            var testSellin = 10;
            var expectedQuality = testQuality + 2;
            var expectedSellin = testSellin - 1;

            Item testItem = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = testQuality,
                SellIn = testSellin
            };

            var items = new List<Item>() { testItem };

            var engine = new GildedRose(items);

            // Act

            engine.UpdateQuality();

            var actualQuality = items.First().Quality;
            var actualSellin = items.First().SellIn;


            // Assert

            Assert.Equal(expectedQuality, actualQuality);
            Assert.Equal(expectedSellin, actualSellin);
        }

        [Fact]
        public void Update_Concert_Tickets_To_Gain_2_Quality_When_Less_Than_6_Days()
        {
            var testQuality = 10;
            var testSellin = 5;
            var expectedQuality = testQuality + 3;
            var expectedSellin = testSellin - 1;

            Item testItem = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = testQuality,
                SellIn = testSellin
            };

            var items = new List<Item>() { testItem };

            var engine = new GildedRose(items);

            // Act

            engine.UpdateQuality();

            var actualQuality = items.First().Quality;
            var actualSellin = items.First().SellIn;


            // Assert

            Assert.Equal(expectedQuality, actualQuality);
            Assert.Equal(expectedSellin, actualSellin);
        }

        [Fact]
        public void Update_Concert_Tickets_To_0_Quality_When_Sellin_Less_Than_0()
        {
            var testQuality = 10;
            var testSellin = -1;
            var expectedQuality = 0;
            var expectedSellin = testSellin - 1;

            Item testItem = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = testQuality,
                SellIn = testSellin
            };

            var items = new List<Item>() { testItem };

            var engine = new GildedRose(items);

            // Act

            engine.UpdateQuality();

            var actualQuality = items.First().Quality;
            var actualSellin = items.First().SellIn;


            // Assert

            Assert.Equal(expectedQuality, actualQuality);
            Assert.Equal(expectedSellin, actualSellin);
        }
    }
}
