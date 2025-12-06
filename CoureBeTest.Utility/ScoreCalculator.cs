namespace CoureBeTest.Utilities
{
    public static class ScoreCalculator
    {
        public static int CalculateScore(int[] numbers)
        {
            int score = 0;

            foreach (var n in numbers)
            {
                if (n % 2 == 0)
                    score += 1;
                else
                    score += 3;

                if (n == 8)
                    score += 5;
            }

            return score;
        }
    }
}
