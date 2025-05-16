using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUtil
{
    /// <summary>
    /// 带权随机
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objs"></param>
    /// <param name="weights"></param>
    /// <returns></returns>
    public static T GetWeightRandom<T>(T[] objs, int[] weights)
    {
        int randomIndex = GetWeightRandomIndex(objs, weights);
        return objs[randomIndex];
    }

    public static int GetWeightRandomIndex<T>(T[] objs, int[] weights)
    {
        List<int> indexes = new List<int>();
        int totalWeight = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            if (i >= objs.Length)
            {
                break;
            }
            int weight = weights[i];
            for (int j = 0; j < weight; j++)
            {
                indexes.Add(i);
            }
            totalWeight += weight;
        }

        int randomIndex = Random.Range(0, totalWeight);
        return indexes[randomIndex];
    }

    public static int GetWeightRandomIndex<T>(Dictionary<T, int> dict)
    {
        T[] keys = new T[dict.Count];
        int[] values = new int[dict.Count];
        dict.Keys.CopyTo(keys, 0);
        dict.Values.CopyTo(values, 0);
        return GetWeightRandomIndex(keys, values);
    }

    public static T GetWeightRandom<T>(Dictionary<T, int> dict)
    {
        T[] keys = new T[dict.Count];
        int[] values = new int[dict.Count];
        dict.Keys.CopyTo(keys, 0);
        dict.Values.CopyTo(values, 0);
        return GetWeightRandom(keys, values);
    }



    public static bool InChance(float chance)
    {
        return Random.Range(0, 100) <= chance * 100;
    }

    public static bool InChance(double chance)
    {
        int random = Random.Range(0, 1000);
        return random <= chance * 1000;
    }

    //public static T GetWeightRandom<T>(Dictionary<T, int> dic)
    //{
    //    List<T> keys = new List<T>();
    //    List<int> weights = new List<int>();
    //    foreach (T key in dic.Keys)
    //    {
    //        keys.Add(key);
    //        weights.Add(dic[key]);
    //    }
    //    int randomIndex = GetWeightRandomIndex(keys.ToArray(), weights.ToArray());
    //    return keys[randomIndex];
    //}
}
