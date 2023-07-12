using System;
using UnityEngine;

namespace Utilities
{
    public class Bricks : MonoBehaviour
    {
        [SerializeField]private BricksSO _data;
        private Renderer _mesh;
        private int _hitsLeft;

        private void Awake()
        {
            _mesh = GetComponent<Renderer>();
        }

        private void Start()
        {
            _mesh.material.SetColor("_Color",_data.Color);
            _hitsLeft = _data.Hits;
        }
    }
}