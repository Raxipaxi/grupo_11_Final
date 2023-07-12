using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utilities
{
    public class Brick : MonoBehaviour
    {
        [SerializeField] private Color[] _colors;
        [field:SerializeField] public bool isBreakable = true;
        [field:SerializeField] public Vector2 Size;
        [SerializeField] private int hits;
        public void ChangeColor()
        {
            if (isBreakable)
            {
                GetComponent<MeshRenderer>().sharedMaterial.color = _colors[hits];
            }
            else
            {
                GetComponent<MeshRenderer>().sharedMaterial.color = _colors[0];

            }
        }

        public void Hit()
        {
            hits--;
            if (hits <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}