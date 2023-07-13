using System;
using UnityEngine;

namespace Assets._Main.Scripts.Generic_Pool
{
    [CreateAssetMenu(fileName = "Pool OBJ", menuName = "Pool", order = 0)]
    public class PoolObject : ScriptableObject
    {
        [field:SerializeField] public int PoolSize { private set; get;}
        [field: SerializeField] public GameObject ObjectToPool { private set; get; }
    }
}