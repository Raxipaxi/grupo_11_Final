using System;
using UnityEngine;

namespace Utilities
{
    public class Bricks : MonoBehaviour
    {
        [SerializeField]private BricksSO _data;
        private Renderer _mesh;
        private Vector2 _size;
        public float Size => _size.x/2;
        private int _hitsLeft;
        private Transform _tr;
        public float PosX => _tr.position.x ;
        public float PosY => _tr.position.y ;


        private void Awake()
        {
            _mesh = GetComponent<Renderer>();
            _size = _mesh.transform.localScale;
            _tr = transform;

        }
        private void Start()
        {
            _hitsLeft = _data.Hits;
        }

        public void Hit()
        {
            _hitsLeft--;
            if (_hitsLeft <= 0)
                Die();
        }
        
        private void Die()
        {
            gameObject.SetActive(false);
            AudioManager.instance.PlaySFXSound(AudioManager.instance.soundReferences.brickDestroyed);
        }
    }
}