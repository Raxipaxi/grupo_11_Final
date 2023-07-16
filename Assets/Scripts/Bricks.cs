using System;
using UnityEngine;
using Utilities.Parents;

namespace Utilities
{
    public class Bricks : Entity
    {
        [SerializeField]private BricksSO _data;
        private Renderer _mesh;
        private int _hitsLeft;


        private void Awake()
        {
            _mesh = GetComponent<Renderer>();
            size = _mesh.transform.localScale;
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