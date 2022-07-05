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
            for (var index = 0; index < _items.Count; index++)
            {
                var t = _items[index];
                int isConjured = 0;
                if (t.Name.StartsWith("[Conjured]"))
                {
                    isConjured = 1;
                    t.Name = t.Name[11..];
                }

                if (t.Name == "Aged Brie")
                {
                    UpdateAgedBrie(t, isConjured);
                }
                else if (t.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateBackstagePass(t, isConjured);
                }
                else if (t.Name != "Sulfuras, Hand of Ragnaros")
                {
                    UpdateNormalItem(t, isConjured);
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

            if (brie.SellIn < 0)
                brie.Quality = brie.Quality + (2 * conjureMultiplier);
            else
                brie.Quality = brie.Quality + (1 * conjureMultiplier);

            if (brie.Quality < 0)
            {
                brie.Quality = 0;
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

            if (backstagePass.SellIn < 0)
                backstagePass.Quality = 0;
            else if (backstagePass.SellIn < 6)
                backstagePass.Quality += 3 + (3 * isConjured);
            else if (backstagePass.SellIn < 11)
                backstagePass.Quality += 2 + (2 * isConjured);
            else
                backstagePass.Quality += 1 + (1 * isConjured);

            if (backstagePass.Quality < 0)
            {
                backstagePass.Quality = 0;
            }

            backstagePass.SellIn--;
        }
        
        private static void UpdateNormalItem(Item normalItem, int isConjured)
        {
            if (normalItem.SellIn >= 0)
            {
                normalItem.Quality -= 1 + (1 * isConjured);
            }
            else if (normalItem.SellIn < 0)
            {
                normalItem.Quality -= 2 + (2 * isConjured);
            }

            if (normalItem.Quality < 0)
            {
                normalItem.Quality = 0;
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

