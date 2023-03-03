using System.Collections.Generic;
using System.Linq;
using GildedRoseChallenge;
using Xunit;

public class GildedRose_Should_
{
    [Fact]
    void Update_The_Quality_Of_Finely_Aged_Brie_To_Increase_With_Time()
    {
        const int testQuality = 10;
        const int expectedQuality = testQuality + 1;
        var testItem = new Item
        {
            Name = "Aged Brie",
            Quality = testQuality,
            SellIn = -2
        };

        var items = new List<Item> { testItem };

        var engine = new GildedRose(items);
        engine.UpdateQuality();

        var actualQuality = items.First().Quality;

        Assert.Equal(expectedQuality, actualQuality);
    }
    
    [Fact]
    void Update_The_Quality_Of_Backstage_Passes_To_Increase_By_1()
    {
        const int testQuality = 10;
        const int expectedQuality = testQuality + 1;
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
    void Update_The_Quality_Of_Backstage_Passes_To_Increase_By_2()
    {
        const int testQuality = 10;
        const int expectedQuality = testQuality + 2;
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
    void Update_The_Quality_Of_Backstage_Passes_To_Increase_By_3()
    {
        const int testQuality = 10;
        const int expectedQuality = testQuality + 3;
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
    void Update_The_Quality_Of_Backstage_Passes_To_0()
    {
        const int testQuality = 10;
        const int expectedQuality = 0;
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
    
    [Fact]
    void Not_Update_The_Quality_Of_Sulfuras()
    {
        const int testQuality = 80;
        const int expectedQuality = testQuality;
        var testItem = new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            Quality = testQuality,
            SellIn = 60
        };

        var items = new List<Item> { testItem };

        var engine = new GildedRose(items);
        engine.UpdateQuality();

        var actualQuality = items.First().Quality;

        Assert.Equal(expectedQuality, actualQuality);
    }
    
    //TODO: make sure that we are cover "Quality is never below 0"
}
