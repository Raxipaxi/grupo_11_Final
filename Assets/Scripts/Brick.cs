using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utilities
{
    public class Brick : MonoBehaviour
    {
        [SerializeField] private Color[] _colors;
        [field:SerializeField] public bool isBreakable;

        public void ChangeColor()
        {
            if (isBreakable)
            {
               GetComponent<MeshRenderer>().sharedMaterial.color = _colors[1];
            }
            else
            {
                GetComponent<MeshRenderer>().sharedMaterial.color = _colors[0];

            }
        }
    }
}