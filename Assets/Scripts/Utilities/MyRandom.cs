using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;
namespace MyEngine
{
    public class MyRandom
    {
        public static float Range(float min, float max)
        {
            float finalValue = 0;
            finalValue = (max - min) * Random.value + min;
            return finalValue;
        }
        public static T GetRandomWeight<T>(Dictionary<T,float> items)
        {
            float total = 0;
            foreach (var item in items)
            {
                total += item.Value;
            }
            float randomVal = Random.value;
            foreach (var item in items)
            {
                var currValue = item.Value / total;
                if(currValue >= randomVal)
                {
                    return item.Key;
                }
                else
                {
                    randomVal -= currValue;
                }
            }

            return default(T);
        }
    public static T[] Shuffle<T>(T[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            var aux = items[i];
            int randomIndex = (int)Range(0,items.Length -1);
            items[i] = items[randomIndex];
                items[randomIndex] = aux;
        }
            return items;
    }
    }
}

