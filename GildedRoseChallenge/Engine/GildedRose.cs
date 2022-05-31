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
               /* switch (_items[i].Name)
                {
                    case "Aged Brie":
                        UpdateQualityBrie(_items[i]);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        // code block
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    default:
                        // code block
                        break;
                }*/


                if (_items[i].Name != "Aged Brie" && _items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (_items[i].Quality > 0)
                    {
                        if (_items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            _items[i].Quality = _items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (_items[i].Quality < 50)
                    {
                        _items[i].Quality = _items[i].Quality + 1;

                        if (_items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (_items[i].SellIn < 11)
                            {
                                if (_items[i].Quality < 50)
                                {
                                    _items[i].Quality = _items[i].Quality + 1;
                                }
                            }

                            if (_items[i].SellIn < 6)
                            {
                                if (_items[i].Quality < 50)
                                {
                                    _items[i].Quality = _items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (_items[i].SellIn < 0)
                {
                    if (_items[i].Name != "Aged Brie")
                    {
                        if (_items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (_items[i].Quality > 0)
                            {
                                if (_items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    _items[i].Quality = _items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            _items[i].Quality = _items[i].Quality - _items[i].Quality;
                        }
                    }
                    else
                    {
                        if (_items[i].Quality < 50)
                        {
                            _items[i].Quality = _items[i].Quality + 1;
                        }
                    }
                }
                if (_items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    _items[i].SellIn = _items[i].SellIn - 1;
                }
            }
        }
        public void UpdateQualityBrie(Item item)
        {
            if (item.Quality < 50)
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

        public void UpdateQualityBackstagePass(Item item)
        {

        }
        public void UpdateQualitySulfuras(Item item)
        {
        
        }
        public void UpdateQualityNormalItem(Item item)
        {
        
        }
    }
    
    
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}

