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
                int isConjured = 0;
                if (t.Name.StartsWith("[Conjured]"))
                {
                    isConjured = 1;
                    t.Name = t.Name[10..];
                }
                switch (t.Name)
                {
                    case "Aged Brie":
                        UpdateAgedBrie(t, isConjured);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateBackstagePass(t, isConjured);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    default:
                        UpdateNormalItem(t, isConjured);
                        break;
                }
            }
        }

        private static void UpdateAgedBrie(Item brie, int isConjured)
        {
            int conjureMultiplier = isConjured + 1;
            if (brie.Quality >= 50)
            {
                brie.SellIn--;
                return;
            }

            switch (brie.SellIn)
            {
                case < 0:
                    brie.Quality = brie.Quality + (2 * conjureMultiplier);
                    break;
                default:
                    brie.Quality = brie.Quality + (1 * conjureMultiplier);
                    break;
            }

            brie.SellIn--;
        }
        
        private static void UpdateBackstagePass(Item backstagePass, int isConjured)
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
                    backstagePass.Quality += 3 + (3 * isConjured);
                    break;
                case < 11:
                    backstagePass.Quality += 2 + (2 * isConjured);
                    break;
                default:
                    backstagePass.Quality += 1 + (1 * isConjured);
                    break;
            }

            backstagePass.SellIn--;
        }
        
//TODO: Handle other normal item cases
        private static void UpdateNormalItem(Item normalItem, int isConjured)
        {
            if (normalItem.Quality > 0 && normalItem.SellIn >= 0)
            {
                normalItem.Quality -= 1 + (1 * isConjured);
            }
            else if (normalItem.Quality > 0 && normalItem.SellIn > 0)
            {
                normalItem.Quality -= 2 + (2 * isConjured);
            }

            normalItem.SellIn--;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}

