using System.Collections.Generic;

namespace LingWords
{
    static class Algorithm
    {
        public static int GetMaxNumberFromList(IList<TranslatePair> list)
        {
            int length = list.Count;
            int max = 0;

            for (int i = 0; i < length; i++)
                if (max < list[i].studyRating)
                    max = list[i].studyRating;

            return max;
        }

        public static int[] CountNumbers(IList<TranslatePair> translatePairs)
        {
            int maximum = GetMaxNumberFromList(translatePairs);
            int count = translatePairs.Count;

            int[] result = new int[maximum + 1];

            int rating;

            for (int i = 0; i < count; i++)
            {
                rating = translatePairs[i].studyRating;
                result[rating]++;
            }

            return result;
        }
    }
}
