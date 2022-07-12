using System.Collections.Generic;

namespace GildedRoseChallenge.Engine
{
    public class GildedRose
    {
        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            this._items = items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
               switch (_items[i].Name)
                {
                    case "Aged Brie":
                        UpdateQualityBrie(_items[i]);
                        _items[i].SellIn -= 1;
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateQualityBackstagePass(_items[i]);
                        _items[i].SellIn -= 1;
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    default:
                        UpdateQualityNormalItem(_items[i]);
                        _items[i].SellIn -= 1;
                        break;
                }
            }
        }
        public static void UpdateQualityBrie(Item item)
        {
            if (item.Quality >= 50)
            {
                return;
            }

            if (item.SellIn < 0)
            {
                item.Quality += 2;
            }
            else
            { 
                item.Quality += 1;
            }
        }

        public static void UpdateQualityBackstagePass(Item item)
        {
            
            if (item.Quality >= 50)
            {
                return;
            }
            
            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }
            
            item.Quality += 1;
            
            if (item.SellIn < 6)
            {
                item.Quality +=2;
            }
            else if (item.SellIn < 11)
            {
                item.Quality += 1;
            }
        }
        public static void UpdateQualityNormalItem(Item item)
        {
            if (item.Quality == 0)
            {
                return;
            }

            if (item.Name.StartsWith("[Conjured]"))
            { 
                UpdateQualityConjuredItem(item);
                return;
            }

            item.Quality -= 1;

            if(item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }
        
        public static void UpdateQualityConjuredItem(Item item)
        {
            item.Quality -= 2;
            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality -= 2;
            }
        }
    }
  
    
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}

