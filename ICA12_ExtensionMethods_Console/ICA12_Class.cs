using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA12_ExtensionMethods_Console
{
    static class ICA12_Class
    {
        //This extension only applies to int lists
        /*
        public static Dictionary<int, int> Categorize(this List<int> sourcelist)
        {
            Dictionary<int, int> newDic = new Dictionary<int, int>();

            sourcelist.ForEach(item =>
            {
                if (newDic.ContainsKey(item))
                    newDic[item] += 1;
                else
                    newDic.Add(item, 1);
            });

            return newDic;
        }
        */

        //This extension is limited to only list collections
        /*
        public static Dictionary<T, int> Categorize<T>(this List<T> sourcelist)
        {
            Dictionary<T, int> newDic = new Dictionary<T, int>();

            sourcelist.ForEach(item =>
            {
                if (newDic.ContainsKey(item))
                    newDic[item] += 1;
                else
                    newDic.Add(item, 1);
            });

            newDic = newDic.OrderBy(item => item.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return newDic;
        }
        */

        public static Dictionary<K, int> Categorize<K>(this IEnumerable<K> sourcelist)
        {
            Dictionary<K, int> newDic = new Dictionary<K, int>();

            foreach (var item in sourcelist)
            {
                if (newDic.ContainsKey(item))
                    newDic[item] += 1;
                else
                    newDic.Add(item, 1);
            }

            newDic = newDic.OrderBy(item => item.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return newDic;
        }

        public static K Popular<K>(this IEnumerable<K> sourcelist)
        {
            Dictionary<K, int> newDic = new Dictionary<K, int>();

            foreach (var item in sourcelist)
            {
                if (newDic.ContainsKey(item))
                    newDic[item] += 1;
                else
                    newDic.Add(item, 1);
            }

            KeyValuePair<K, int> maxVal = newDic.Aggregate((a, b) => a.Value > b.Value ? a : b);
            //newDic = newDic.OrderByDescending(item => item.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return newDic.First().Key;
        }

        public static IEnumerable<K> Shuffle<K>(this IEnumerable<K> sourcelist, Random rnd)
        {
            List<K> shuffledList = new List<K>(sourcelist);
            for (int i = 0; i < shuffledList.Count(); ++i)
            {
                int j = rnd.Next(i, shuffledList.Count());
                K temp = shuffledList[j];
                shuffledList[j] = shuffledList[i];
                shuffledList[i] = temp;
            }

            return shuffledList;
        }
    }
}
