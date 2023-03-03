using System.Collections.Generic;

namespace GildedRoseChallenge
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateAgedBrie(Items[i]);
                UpdateBackstagePass(Items[i]);
                
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                // else
                // {
                //     if (Items[i].Quality < 50)
                //     {
                //          // this will mess up Backstage Pass until we refactor it
                //          // Items[i].Quality = Items[i].Quality + 1;
                //
                //         // if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                //         // {
                //         //     if (Items[i].SellIn < 11)
                //         //     {
                //         //         if (Items[i].Quality < 50)
                //         //         {
                //         //             Items[i].Quality = Items[i].Quality + 1;
                //         //         }
                //         //     }
                //         //
                //         //     if (Items[i].SellIn < 6)
                //         //     {
                //         //         if (Items[i].Quality < 50)
                //         //         {
                //         //             Items[i].Quality = Items[i].Quality + 1;
                //         //         }
                //         //     }
                //         // }
                //     }
                // }

                // if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                // {
                //     Items[i].SellIn = Items[i].SellIn - 1;
                // }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    // else
                    // {
                    //     if (Items[i].Quality < 50)
                    //     {
                    //         // aged brie gets updated a second time here
                    //         Items[i].Quality = Items[i].Quality + 1;
                    //     }
                    // }
                }
            }
        }

        private void UpdateAgedBrie(Item item)
        {
            if (item.Name == "Aged Brie" && item.Quality < 50)
            {
                item.SellIn -= 1;
                item.Quality += 1;
            }
        }
        
        private void UpdateBackstagePass(Item item)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Quality < 50)
            {
                switch (item.SellIn)
                {
                    case > 11:
                        item.Quality += 1;
                        break;
                    case < 11 and > 5 :
                        item.Quality += 2;
                        break;
                    case < 6 and > 0 :
                        item.Quality += 3;
                        break;
                    default:
                        item.Quality = 0;
                        break;
                }
                
                item.SellIn -= 1;
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

