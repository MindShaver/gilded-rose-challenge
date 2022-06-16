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
                switch (t.Name)
                {
                    case "Aged Brie":
                        UpdateAgedBrie(t);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateBackstagePass(t);
                        break;
                    default:
                    {
                        if (t.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            UpdateNormalItem(t);
                        }

                        break;
                    }
                }
            }
        }

        private static void UpdateAgedBrie(Item brie)
        {
            if (brie.Quality >= 50)
            {
                brie.SellIn--;
                return;
            }

            switch (brie.SellIn)
            {
                case < 0:
                    brie.Quality = brie.Quality + 2;
                    break;
                default:
                    brie.Quality = brie.Quality + 1;
                    break;
            }

            brie.SellIn--;
        }
        
        private static void UpdateBackstagePass(Item backstagePass)
        {
            if (backstagePass.Quality >= 50)
            {
                backstagePass.SellIn--;
                return;
            }

            switch (backstagePass.SellIn)
            {
                case < 0:
                    backstagePass.Quality = 0;
                    break;
                case < 6:
                    backstagePass.Quality = backstagePass.Quality + 3;
                    break;
                case < 11:
                    backstagePass.Quality = backstagePass.Quality + 2;
                    break;
                default:
                    backstagePass.Quality = backstagePass.Quality + 1;
                    break;
            }

            backstagePass.SellIn--;
        }

        private static void UpdateNormalItem(Item normalItem)
        {
            if (normalItem.Quality > 0 && normalItem.SellIn >= 0)
            {
                normalItem.Quality--;
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

