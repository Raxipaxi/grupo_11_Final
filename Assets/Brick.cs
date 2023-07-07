using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utilities
{
    public class Brick : MonoBehaviour
    {
        [SerializeField] private Color[] _colors;

        private void Start()
        {
            GetComponent<MeshRenderer>().material.color = _colors[Random.Range(0,_colors.Length)];
        }
    }
}