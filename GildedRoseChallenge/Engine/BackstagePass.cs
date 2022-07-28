namespace GildedRoseChallenge.Engine
{
    public static class BackstagePass
    {
        public static void UpdateBackstagePass(Item backstagePass, int isConjured)
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
    }
}