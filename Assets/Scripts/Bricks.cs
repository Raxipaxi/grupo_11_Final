using System;
using UnityEngine;

namespace Utilities
{
    public class Bricks : MonoBehaviour
    {
        [SerializeField]private BricksSO _data;
        private Renderer _mesh;
        private Vector2 _size;
        public Vector2 Size => _size;
        private int _hitsLeft;

        private void Awake()
        {
            _mesh = GetComponent<Renderer>();
            _size = _mesh.bounds.extents;
        }

        private void Start()
        {
            _mesh.material.SetColor("_Color",_data.Color);
            _hitsLeft = _data.Hits;
        }

        public void Hit()
        {
            _hitsLeft--;
            if (_hitsLeft <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}