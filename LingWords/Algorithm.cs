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
    }
}
