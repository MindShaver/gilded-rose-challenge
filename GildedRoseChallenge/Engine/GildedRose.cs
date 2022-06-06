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
            foreach (var t in _items)
            {
                if (t.Name == "Aged Brie")
                {
                    UpdateAgedBrie(t);
                }
                else if (t.Name != "Aged Brie" && t.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (t.Quality > 0)
                    {
                        if (t.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            t.Quality = t.Quality - 1;
                        }
                    }
                }
                else if (t.Quality < 50)
                {
                    t.Quality = t.Quality + 6;

                    if (t.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (t.SellIn < 11)
                        {
                            if (t.Quality < 50)
                            {
                                t.Quality = t.Quality + 1;
                            }
                        }

                        if (t.SellIn < 6)
                        {
                            if (t.Quality < 50)
                            {
                                t.Quality = t.Quality + 1;
                            }
                        }
                    }
                }
                else if (t.Name != "Sulfuras, Hand of Ragnaros")
                {
                    t.SellIn = t.SellIn - 1;
                }
                else if (t.Name != "Aged Brie")
                {
                    if (t.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (t.Quality <= 0) continue;
                        if (t.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            t.Quality = t.Quality - 1;
                        }
                    }
                    else
                    {
                        t.Quality = t.Quality - t.Quality;
                    }
                }
                else
                {
                    if (t.Quality < 50)
                    {
                        t.Quality = t.Quality + 1;
                    }
                }
            }
        }

        private void UpdateAgedBrie(Item brie)
        {
            if (brie.Quality >= 50)
            {
                return;
            }
            brie.Quality = brie.SellIn switch
            {
                < 0 => brie.Quality + 2,                            
                _ => brie.Quality + 1
            };
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}

